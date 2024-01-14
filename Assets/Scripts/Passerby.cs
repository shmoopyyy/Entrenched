using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passerby : MonoBehaviour
{
  /* Sprite parameters */
  public string spritePath = "passerby_sprites";
  public SpriteRenderer spriteRenderer;
  private Sprite[] sprites;
  private int sprite_version;
  private int num_sprites;

  /* Movement parameters */
  public float leftBound = -8;
  public float moveSpeed = 5;
  private GameManager GM;

  // Start is called before the first frame update
  void Start()
  {
    GM = GameManager.instance;
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    sprites = Resources.LoadAll<Sprite>("Characters");
    num_sprites = sprites.Length;
    Debug.Log("there are " + num_sprites + " sprites loaded.");

  }

  // Update is called once per frame
  void Update()
  {
    if (GM.clock == 0) {
      Debug.Log("clock is zero");
      sprite_version = (sprite_version + 1) % num_sprites;
      spriteRenderer.sprite = sprites[sprite_version];
    }

    float currPos = transform.position.x;
    if (currPos >= leftBound) {
      transform.Translate(Vector2.left *moveSpeed * Time.deltaTime);
    } else {
      Debug.Log(currPos);
    }
  }
}
