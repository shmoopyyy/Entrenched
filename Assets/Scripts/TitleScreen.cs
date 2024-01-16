using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
  public string mainScene = "MainGame";
  public void StoryModeButton()
  {
    GameManager.storyModeEnabled = true;
    GameManager.initDistance = 0;
    GameManager.startedOnce = false;
    CutsceneManager.panelsPath = "Cutscenes/Opening";
    SceneManager.LoadScene("Cutscene");

  }

  public void EndlessModeButton()
  {
    GameManager.storyModeEnabled = false;
    Debug.Log("Endless mode clicked");
    SceneManager.LoadScene(mainScene);
  }

}
