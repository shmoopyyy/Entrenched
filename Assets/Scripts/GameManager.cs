using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public string mainScene = "MainGame";
  public string gameOverScene = "GameOver";
  public const int STRIKE_LIMIT = 3;
  public const int STABILITY_LIMIT = 100;
  public const double DISTANCE_SCALAR = 1.0;
  public const float STABILITY_SCALAR = 1.2f;

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

  public bool awaitingAnswer = false;
  public bool miniWin = false;
  public bool miniOver = false;
  public int questionValue = 0;
  public bool nextDialogue = false;
  public GameObject dialogSet;

  // Singleton instance
  public static GameManager instance;
  void Awake()
  {
    if(instance == null) {
      instance = this;
    };

  }

  // 'global' state trackers
  public static bool isWinner = false;
  public double distance = 0;
  public bool timeOn = true;
  public float stability = STABILITY_LIMIT;
  public int numStrikes = 0;
  public static bool storyModeEnabled = true;
  public static bool startedOnce = false;
  public static bool threeKids = false;
  public static float initDistance = 0;
  public SpriteRenderer playerRender;
  public Sprite threeSprite;
  public Sprite twoSprite;
  public static bool doneScene1 = false;
  public static bool muffleMusic = false;

  public RestabilizeGame boxGamePrefab;
  public DDRGame ddrGamePrefab;
  public ReactionGame reactionGamePrefab;

  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("This is the start of game manager.");
    Debug.Log("Story mode on?: " + storyModeEnabled);
    if (threeKids || !storyModeEnabled) {
      playerRender.sprite = threeSprite;
      MusicManager.twoKidMode = false;
    } else {
      playerRender.sprite = twoSprite;
      MusicManager.twoKidMode = true;
    }
    distance = initDistance;

  }

  public void startRestab()
  {
    RestabilizeGame minigame = Instantiate(boxGamePrefab);
    minigame.transform.position += new Vector3(0, 0, -3);
  }

  public void startDDR()
  {
    timeOn = false;
    DDRGame minigame = Instantiate(ddrGamePrefab);
    minigame.transform.position += new Vector3(0, 0, -3);
  }

  public void startReaction()
  {
    timeOn = false;
    ReactionGame minigame = Instantiate(reactionGamePrefab);
    minigame.transform.position += new Vector3(0, 0, -3);
  }

  // Update is called once per frame
  void Update()
  {
    if (timeOn) {
      if (numStrikes >= STRIKE_LIMIT) {
        isWinner = false;
        SceneManager.LoadScene(gameOverScene);
      }
      distance += (Time.deltaTime * DISTANCE_SCALAR);
      if (stability > 0) {
        stability -= (Time.deltaTime * STABILITY_SCALAR);
      } else {
        stability = 0;
        isWinner = false;
        SceneManager.LoadScene(gameOverScene);
      }

      // If story mode on, check if reached cutscene distance
      if (storyModeEnabled) {
        if (distance >= END_CUTSCENE_DIST) {
          // load ending cutscene
          isWinner = true;
          CutsceneManager.panelsPath = CUTSCENE_PATHS[END_SCENE];
          SceneManager.LoadScene(cutScene);
        } else if (distance >= MID_CUTSCENE_DIST && !doneScene1) {
          // load middle cutscene
          doneScene1 = true;
          CutsceneManager.panelsPath = CUTSCENE_PATHS[MID_SCENE];
          SceneManager.LoadScene(cutScene);
        }
      }

      // Temporary minigame activators
      if (Input.GetKeyDown(KeyCode.B)) {
        startRestab();
      }

      if (miniOver) {
        if (questionValue < 0 && !miniWin) {
          miniOver = false;
          numStrikes += 1;
        } else if (questionValue < 0 && miniWin) {
          miniOver = false;
          stability -= 10;
          questionValue = 0;
          miniWin = false;
        } else if (!miniWin && questionValue >=0) {
          miniOver = false;
          stability -= 10;
          questionValue = 0;
          miniWin = false;
        } 
      }

    }

    // Time toggle, always listening
    if (Input.GetKeyDown(KeyCode.Escape)) {
      timeOn = !timeOn;
    }
  }
}
