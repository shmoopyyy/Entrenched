using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  void Awake()
  {
    if(instance == null) {
      instance = this;
    };
  }

  public string msg = "hello";
  public int clock = 0;
  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("This is the start of game manager.");

  }

  // Update is called once per frame
  void Update()
  {
    clock = (clock + 1) % 100;
    Debug.Log(clock);

  }
}
