using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public string mainScene = "MainGame";
  public const int STRIKE_LIMIT = 3;
  public const int STABILITY_LIMIT = 100;
  public const double DISTANCE_SCALAR = 1.0;
  public const float STABILITY_SCALAR = 3;

  /* Story mode info */
  public const float MID_CUTSCENE_DIST = 100;
  public const float END_CUTSCENE_DIST = 200;
  
  public string cutScene = "Cutscene";
  public const int OPEN_SCENE = 0;
  public const int MID_SCENE = 1;
  public const int END_SCENE = 2;
  public string[] CUTSCENE_PATHS = {
    "Cutscenes/Opening",
    "Cutscenes/Middle",
    "Cutscenes/Ending"
  };

  // Singleton instance
  public static GameManager instance;
  void Awake()
  {
    if(instance == null) {
      instance = this;
    };

  }

  // 'global' state trackers
  public double distance = 0;
  public bool timeOn = true;
  public int score = 0;
  public float stability = STABILITY_LIMIT;
  public int numStrikes = 0;
  public static bool storyModeEnabled = true;

  public RestabilizeGame boxGamePrefab;
  public DDRGame ddrGamePrefab;
  public ReactionGame reactionGamePrefab;

  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("This is the start of game manager.");
    Debug.Log("Story mode on?: " + storyModeEnabled);

  }

  // Update is called once per frame
  void Update()
  {
    if (timeOn) {
      distance += (Time.deltaTime * DISTANCE_SCALAR);
      if (stability > 0) {
        stability -= (Time.deltaTime * STABILITY_SCALAR);
      } else {
        stability = 0;
      }

      // If story mode on, check if reached cutscene distance
      if (storyModeEnabled) {
        if (distance >= END_CUTSCENE_DIST) {
          // load ending cutscene
          CutsceneManager.panelsPath = CUTSCENE_PATHS[END_SCENE];
          SceneManager.LoadScene(cutScene);
        } else if (distance >= MID_CUTSCENE_DIST) {
          // load middle cutscene
          CutsceneManager.panelsPath = CUTSCENE_PATHS[MID_SCENE];
          SceneManager.LoadScene(cutScene);
        }
      }

      // Temporary minigame activators
      if (Input.GetKeyDown(KeyCode.B)) {
        RestabilizeGame minigame = Instantiate(boxGamePrefab);
        minigame.transform.position += new Vector3(0, 0, -3);
      }
      if (Input.GetKeyDown(KeyCode.D)) {
        timeOn = false;
        DDRGame minigame = Instantiate(ddrGamePrefab);
        minigame.transform.position += new Vector3(0, 0, -3);
      }
      if (Input.GetKeyDown(KeyCode.R)) {
        timeOn = false;
        ReactionGame minigame = Instantiate(reactionGamePrefab);
        minigame.transform.position += new Vector3(0, 0, -3);
      }
    }

    // Time toggle, always listening
    if (Input.GetKeyDown(KeyCode.Escape)) {
      timeOn = !timeOn;
    }
  }
}
