using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
  public static MusicManager instance;
  public AudioSource mainTheme2;
  public AudioSource muffledTheme2;
  public AudioSource mainTheme3;
  public AudioSource muffledTheme3;
  public static bool twoKidMode = true;
  public static bool muffleOn = false;

  private GameManager GM;
  // Start is called before the first frame update
  void Awake()
  {
    if(instance == null) {
      instance = this;
    }

  }
  void Start()
  {
    GM = GameManager.instance;
    mainTheme2.Stop();
    muffledTheme2.Stop();
    mainTheme3.Stop();
    muffledTheme3.Stop();

    if (twoKidMode) {
      mainTheme2.mute = false;
    } else {
      mainTheme3.mute = false;
    }
    mainTheme2.Play();
    muffledTheme2.Play();
    mainTheme3.Play();
    muffledTheme3.Play();
  }

  public void toggleMuffled() 
  {
    if (twoKidMode) {
      if (!muffleOn) {
        muffleOn = true;
        mainTheme2.mute = true;
        muffledTheme2.mute = false;
      } else {
        muffleOn = false;
        muffledTheme2.mute = true;
        mainTheme2.mute = false;
      }
    } else {
      if (!muffleOn) {
        muffleOn = true;
        mainTheme3.mute = true;
        muffledTheme3.mute = false;
      } else {
        muffleOn = false;
        muffledTheme3.mute = true;
        mainTheme3.mute = false;
      }
    }

  }
  // Update is called once per frame
  void Update()
  {
      
  }
}
