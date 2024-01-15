//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class Dialogue : MonoBehaviour
//{
//    public GameObject popUpBox;
//    public Animator animator;
//    public TMP_Text popUpText;

//    public void PopUp(string text)
//    {
//        popUpBox.SetActive(true);
//        popUpText.text = text;
//        animator.SetTrigger("pop");
//    }
//}


////public class DialogueManager : MonoBehaviour
////{
////    public GameObject dialoguePanel;
////    public Text dialogueText;
////    public Button[] optionButtons;

////    void Start()
////    {
////        dialoguePanel.SetActive(false); // dialogue doesnt pop up yet
////    }

////    public void ShowDialogue(string text, string[] options)
////    {
////        dialogueText.text = text;
////        for (int i = 0; i < options.Length; i++)
////        {
////            optionButtons[i].GetComponentInChildren<Text>().text = options[i];
////            optionButtons[i].gameObject.SetActive(true);
////        }
////        dialoguePanel.SetActive(true);
////    }

////    // Method to call when an option is selected
////    public void OnOptionSelected(int optionIndex)
////    {
////        // the kids choices

////        dialoguePanel.SetActive(false); // the dialogue leaves
////    }
////}


//////turn the ui stuff into a prefab object
//////copy the panel into the prefab object