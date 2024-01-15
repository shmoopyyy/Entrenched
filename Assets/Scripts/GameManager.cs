using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public const int STRIKE_LIMIT = 3;
  public const int STABILITY_LIMIT = 100;
  public const int CLOCK_LIMIT = 1000;
  public const double DISTANCE_SCALAR = 1.0;
  public const float STABILITY_SCALAR = 3;

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

  public RestabilizeGame boxGamePrefab;
  public DDRGame ddrGamePrefab;
  public ReactionGame reactionGamePrefab;

  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("This is the start of game manager.");

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

      // Temporary minigame activators
      if (Input.GetKeyDown(KeyCode.B)) {
        Instantiate(boxGamePrefab);
      }
      if (Input.GetKeyDown(KeyCode.D)) {
        Instantiate(ddrGamePrefab);
      }
      if (Input.GetKeyDown(KeyCode.R)) {
        Instantiate(reactionGamePrefab);
      }
    }

    // Time toggle, always listening
    if (Input.GetKeyDown(KeyCode.Escape)) {
      timeOn = !timeOn;
    }
  }
}
