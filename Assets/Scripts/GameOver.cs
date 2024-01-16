using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public string titleScene = "TitleScreen";
  private GameManager GM;
  public TMPro.TextMeshProUGUI marqueeText;

  public void toTitle()
  {
    // GM.resetGame();   // implement this
    SceneManager.LoadScene(titleScene);
  }

  // Start is called before the first frame update
  void Start()
  {
    GM = GameManager.instance;
    if (GameManager.isWinner) {
      marqueeText.text = "You Win!";
    } else {
      marqueeText.text = "Game Over!";
    }
    GameManager.startedOnce = false;
    GameManager.isWinner = false;
    GameManager.initDistance = 0;
    GameManager.doneScene1 = false;

  }

  // Update is called once per frame
  void Update()
  {

  }
}
