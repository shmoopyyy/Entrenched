using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRGame : MonoBehaviour
{
  public const float MOVE_SPEED = 4;
  public const int ARROW_LIMIT = 5;
  public KeyCode[] keyCodes = {KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow};
  private int currentArrowNum = 0;
  private int directionNum;
  private GameObject currentArrow;
  private PolygonCollider2D currentArrowCollider;

  public GameObject[] arrows;
  // public PolygonCollider2D[] arrowColliders;
  public BoxCollider2D inputBoxCollider;
  public BoxCollider2D killCollider;

  public AudioSource source;
  public AudioClip[] successNotes;
  public AudioClip[] failNotes;
  public GameObject background;

  private bool isInBox = false;
  private bool isInKillBox = false;
  private Vector3 bgOffset;

    // Start is called before the first frame update
    void newArrow()
    {
      directionNum = Random.Range(0, arrows.Length);
      currentArrow = Instantiate(arrows[directionNum]);
      currentArrow.transform.position = Vector3.up * 6.5f + bgOffset;
      // currentArrow.transform.localScale = new Vector3(1f, 1f, 1f);
      // currentArrow.transform.localPosition = new Vector3(20f, 6.5f, 1.8f);
      currentArrowCollider = currentArrow.GetComponentInChildren<PolygonCollider2D>();
      Debug.Log(currentArrowCollider);
    }
    void Start()
    {
      bgOffset = background.transform.position;
      bgOffset.z = 0;
      Debug.Log(bgOffset);

      newArrow();
    }

    IEnumerator ddrLose()
    {
      Debug.Log("You lose!");
      yield return new WaitForSeconds(1.5f);
      Object.Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      if (!(currentArrowNum < ARROW_LIMIT)) {
        Debug.Log("You win!");
        Object.Destroy(currentArrow.gameObject);
        Object.Destroy(this.gameObject);
      }

      if (currentArrow.gameObject != null) {
        isInBox = currentArrowCollider == Physics2D.OverlapArea(inputBoxCollider.bounds.min, inputBoxCollider.bounds.max, LayerMask.GetMask("Box0"));
        isInKillBox = currentArrowCollider == Physics2D.OverlapArea(killCollider.bounds.min, killCollider.bounds.max, LayerMask.GetMask("Box0"));
        if (isInKillBox) {
          // source.PlayOneShot(failNotes[currentArrowNum]);
          Object.Destroy(currentArrow.gameObject);
          StartCoroutine(ddrLose());
        }
        if (isInBox) {
          if (Input.GetKeyDown(keyCodes[directionNum])) {
            // source.PlayOneShot(successNotes[currentArrowNum]);
            Object.Destroy(currentArrow.gameObject);
            currentArrowNum += 1;
            newArrow();

          }
        }
        currentArrow.transform.Translate(Vector2.down * MOVE_SPEED * Time.deltaTime);
      }
    }
}
