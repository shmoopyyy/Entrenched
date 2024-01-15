using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkFile;
    public GameObject textBox;
    public GameObject customButton;
    public GameObject optionPanel;
    public Text stabilityScoreText; // UI Text element to display stability score

    private Story story;
    private Text nametag;
    private Text message;
    private int stabilityScore = 10; // Initial stability score, adjust as needed

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkFile.text);
        nametag = textBox.transform.GetChild(0).GetComponent<Text>();
        message = textBox.transform.GetChild(1).GetComponent<Text>();
        stabilityScoreText.text = "Stability: " + stabilityScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (story.canContinue)
            {
                nametag.text = "Character Name"; // Replace with actual character name
                AdvanceDialogue();

                if (story.currentChoices.Count != 0)
                {
                    StartCoroutine(ShowChoices());
                }
            }
            else
            {
                FinishDialogue();
            }
        }
    }

    private void FinishDialogue()
    {
        Debug.Log("End of Dialogue! Final Stability Score: " + stabilityScore);
        // Additional logic based on final stability score
    }

    void AdvanceDialogue()
    {
        string currentSentence = story.Continue();
        stabilityScore = (int)story.variablesState["stability"];
        stabilityScoreText.text = "Stability: " + stabilityScore.ToString();
        ParseTags();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }
    }

    IEnumerator ShowChoices()
    {
        Debug.Log("Choices available.");
        List<Choice> _choices = story.currentChoices;
        optionPanel.SetActive(true);

        foreach (Choice choice in _choices)
        {
            GameObject tempButton = Instantiate(customButton, optionPanel.transform);
            tempButton.transform.GetChild(0).GetComponent<Text>().text = choice.text;
            tempButton.GetComponent<Button>().onClick.AddListener(() => MakeChoice(choice.index));
        }

        yield return new WaitUntil(() => !optionPanel.activeSelf);
    }

    public void MakeChoice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        foreach (Transform child in optionPanel.transform)
        {
            Destroy(child.gameObject);
        }
        optionPanel.SetActive(false);
        AdvanceDialogue();
    }

    void ParseTags()
    {
        // Implement tag parsing logic as needed
    }
}
