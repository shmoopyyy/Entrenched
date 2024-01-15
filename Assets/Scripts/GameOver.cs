using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public string titleScene = "TitleScreen";
  private GameManager GM;
  
  public void toTitle()
  {
    GM = GameManager.instance;
    // GM.resetGame();   // implement this
    SceneManager.LoadScene(titleScene);
  }

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      
  }
}
