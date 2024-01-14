using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passerby : MonoBehaviour
{
  /* Sprite parameters */
  // public string spritePath = "passerby_sprites";
  public SpriteRenderer spriteRenderer;
  // private Sprite[] sprites;
  // public int sprite_version;
  // private int num_sprites;

  /* Movement parameters */
  public float leftBound = -8;
  public float moveSpeed = 5;
  public bool movementOn = false;
  private GameManager GM;

  // Start is called before the first frame update
  void Start()
  {
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

  }

  // Update is called once per frame
  void Update()
  {

    float currPos = transform.position.x;
    if (movementOn && currPos >= leftBound) {
      transform.Translate(Vector2.left *moveSpeed * Time.deltaTime);
    }

  }
}
