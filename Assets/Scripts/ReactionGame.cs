using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionGame : MonoBehaviour
{
  public const float START_DELAY = 2f;
  public const float MAX_DELAY = 1.5f;
  public const float REACTION_TIME = 0.2f;  // 200 milliseconds
  public AudioSource source;
  public AudioClip winClip;
  public AudioClip loseClip;
  public GameObject buttonPrompt;
  private GameObject buttonPromptDisplay;
  private bool inSecondHalf = false;
  private bool isOnScreen = false;
  private float offset;
  private float timeLeft = START_DELAY;

  // Start is called before the first frame update
  IEnumerator delay(float seconds)
  {
    yield return new WaitForSeconds(seconds);
  }
  void Start()
  {
    offset = Random.Range(0, MAX_DELAY);
    timeLeft += offset;
  }
  

  // Update is called once per frame
  void Update()
  {
    timeLeft -= Time.deltaTime;
    if (timeLeft <= 0) {
      if (!inSecondHalf) {
        inSecondHalf = true;
        isOnScreen = true;
        buttonPromptDisplay = Instantiate(buttonPrompt);
        timeLeft = REACTION_TIME;
      } else {
        // remove button from screen, time is up
        Object.Destroy(buttonPromptDisplay.gameObject);
      }
    }

    if (Input.GetKeyDown(KeyCode.Space)) {
      if (isOnScreen) {
        source.PlayOneShot(winClip);
        Debug.Log("You win!");
        StartCoroutine(delay(1.5f));
        Object.Destroy(buttonPromptDisplay.gameObject);
        Object.Destroy(this.gameObject);
      } else {
        source.PlayOneShot(loseClip);
        Debug.Log("You lose!");
        StartCoroutine(delay(2f));
        Object.Destroy(buttonPromptDisplay.gameObject);
        Object.Destroy(this.gameObject);
      }
    }


  }
}