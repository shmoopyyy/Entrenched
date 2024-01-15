using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
  public string mainScene = "MainGame";
  public static bool storyModeEnabled;
  public void StoryModeButton()
  {
    storyModeEnabled = true;
    SceneManager.LoadScene(mainScene);
  }

  public void EndlessModeButton()
  {
    storyModeEnabled = false;
    Debug.Log("Endless mode clicked");
    SceneManager.LoadScene(mainScene);
  }

}
