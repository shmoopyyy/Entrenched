using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public const int STRIKE_LIMIT = 3;
  public const int STABILITY_LIMIT = 100;
  public const int CLOCK_LIMIT = 1000;

  // Singleton instance
  public static GameManager instance;
  void Awake()
  {
    if(instance == null) {
      instance = this;
    };
  }

  // 'global' state trackers
  public int clock = 0;
  public int score = 0;
  public int stability = STABILITY_LIMIT;
  public int numStrikes = 0;


  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("This is the start of game manager.");

  }

  // Update is called once per frame
  void Update()
  {
    clock = (clock + 1) % CLOCK_LIMIT;
    if (clock % CLOCK_LIMIT == 0) {
      Debug.Log("Hello! clock value is : " + clock);

    }

  }
}
