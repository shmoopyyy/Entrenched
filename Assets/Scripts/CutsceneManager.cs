using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
  public static string panelsPath = "Cutscenes/Opening";
  public SpriteRenderer panelView;
  private Sprite[] panels;
  private int numPanels = 0;
  private int currentPanel = 0;
  private GameManager GM;

  public void nextPanel()
  {
    Debug.Log("old panel is " + currentPanel);
    currentPanel = Mathf.Min(currentPanel + 1, numPanels);
    panelView.sprite = panels[currentPanel];
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
