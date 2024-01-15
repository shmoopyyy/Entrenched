using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRGame : MonoBehaviour
{
  public const float MOVE_SPEED = 2;
  public const int ARROW_LIMIT = 5;
  private int currentArrowNum = 0;
  private GameObject currentArrow;
  private PolygonCollider2D currentArrowCollider;

  public GameObject[] arrows;
  // public PolygonCollider2D[] arrowColliders;
  public BoxCollider2D inputBoxCollider;
  public BoxCollider2D killCollider;

  public AudioSource source;
  public AudioClip[] successNotes;
  public AudioClip[] failNotes;

  private bool isInBox = false;
  private bool isInKillBox = false;

    // Start is called before the first frame update
    void Start()
    {
      // randomly choose one of four arrows, instantiate.
      // set current arrow collider
      currentArrow = Instantiate(arrows[Random.Range(0, arrows.Length)]);
      currentArrowCollider = currentArrow.GetComponentInChildren<PolygonCollider2D>();
      Debug.Log(currentArrowCollider);
      
        
    }

    // Update is called once per frame
    void Update()
    {
      isInBox = currentArrowCollider == Physics2D.OverlapArea(inputBoxCollider.bounds.min, inputBoxCollider.bounds.max, LayerMask.GetMask("Box0"));
      isInKillBox = currentArrowCollider == Physics2D.OverlapArea(killCollider.bounds.min, killCollider.bounds.max, LayerMask.GetMask("Box0"));
      if (isInKillBox) {
        Debug.Log("You lose!");
        // source.PlayOneShot(failNotes[currentArrowNum]);
        // Object.Destroy(currentArrow.gameObject);
      }
      currentArrow.transform.Translate(Vector2.down * MOVE_SPEED * Time.deltaTime);
    }
}
