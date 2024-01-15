using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionDisplay : MonoBehaviour
{
  private GameManager GM;
  public SpriteRenderer spriteRenderer0;
  public SpriteRenderer spriteRenderer1;
  public SpriteRenderer spriteRenderer2;
  public Sprite unfilled;
  public Sprite filled;
  
  // Start is called before the first frame update
  void Start()
  {
    GM = GameManager.instance;
    spriteRenderer0.sprite = unfilled;
    spriteRenderer1.sprite = unfilled;
    spriteRenderer2.sprite = unfilled;
  }

  // Update is called once per frame
  void Update()
  {
    if (GM.numStrikes >= 0) {
      spriteRenderer0.sprite = filled;
    }
    if (GM.numStrikes >= 1) {
      spriteRenderer1.sprite = filled;
    }
    if (GM.numStrikes >= 2) {
      spriteRenderer2.sprite = filled;
    }

  }
}
