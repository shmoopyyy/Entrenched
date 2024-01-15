using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passerby : MonoBehaviour
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
    // spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    GM = GameManager.instance;

  }

  // Update is called once per frame
  void Update()
  {

    float currPos = transform.position.x;
    if (GM.timeOn) {
      if (currPos >= leftBound) {
        transform.Translate(Vector2.left *moveSpeed * Time.deltaTime);
      } else {
        NPCManager.passerbyPresent = false;
        Object.Destroy(this.gameObject);
      }

    }

  }
}
