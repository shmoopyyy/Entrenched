using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGPasserby : MonoBehaviour
{
 /* Sprite parameters */
  public SpriteRenderer spriteRenderer;

  /* Movement parameters */
  public float leftBound = -8;
  public float moveSpeed = 5;
  private GameManager GM;

  // Start is called before the first frame update
  void Start()
  {
    GM = GameManager.instance;

  }

  // Update is called once per frame
  void Update()
  {

    if (GM.timeOn) {
      float currPos = transform.position.x;
      if (currPos >= leftBound) {
        transform.Translate(Vector2.left *moveSpeed * Time.deltaTime);
      } else {
        Object.Destroy(this.gameObject);
      }
    }

  }
}
