using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
  public static string panelsPath = "Cutscenes/Opening";
  public SpriteRenderer panelView;
  private Sprite[] panels;
  private int numPanels = 0;
  private int currentPanel = 0;
  private GameManager GM;
  public AudioSource source;
  public AudioClip[] clips;

  public void nextPanel()
  {
    // random choice of sound
    source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    Debug.Log("old panel is " + currentPanel);
    currentPanel = Mathf.Min(currentPanel + 1, numPanels);
    if (currentPanel >= numPanels) {
      if (panelsPath == "Cutscenes/Middle") {
        GameManager.threeKids = true;
        MusicManager.twoKidMode = true;
        GameManager.initDistance = GameManager.MID_CUTSCENE_DIST;
      } else {
        GameManager.startedOnce = true;
        GameManager.threeKids = false;
        MusicManager.twoKidMode = true;
      }
      if (panelsPath == "Cutscenes/Ending") {
        GameManager.isWinner = true;
        SceneManager.LoadScene("GameOver");
      } else {
        SceneManager.LoadScene("MainGame");
      }
    } else {
      panelView.sprite = panels[currentPanel];
    }
    Debug.Log("current panel is now " + currentPanel);
  }

  // Start is called before the first frame update
  void Start()
  {
    GM = GameManager.instance;
    panels = Resources.LoadAll<Sprite>(panelsPath);
    numPanels = panels.Length;
    if (numPanels > 0) {
      panelView.sprite = panels[0];
    }
    Debug.Log("there are " + numPanels + " panels loaded.");

  }

  // Update is called once per frame
  void Update()
  {

  }
}
