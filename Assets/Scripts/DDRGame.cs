using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRGame : MonoBehaviour
{
  public const float MOVE_SPEED = 15;
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
  public AudioClip winClip;
  public AudioClip[] successNotes;
  public AudioClip[] failNotes;
  public GameObject background;

  private bool isInBox = false;
  private bool isInKillBox = false;
  private Vector3 bgOffset;
  private bool gameOver = false;
  private GameManager GM;

    // Start is called before the first frame update
    void newArrow()
    {
      directionNum = Random.Range(0, arrows.Length);
      currentArrow = Instantiate(arrows[directionNum]);
      currentArrow.transform.position = Vector3.up * 10f + bgOffset;
      currentArrowCollider = currentArrow.GetComponentInChildren<PolygonCollider2D>();
      Debug.Log(currentArrowCollider);
    }
    void Start()
    {
      GM = GameManager.instance;
      bgOffset = background.transform.position;
      bgOffset.z = 0;
      Debug.Log(bgOffset);

      newArrow();
    }

    IEnumerator ddrExit()
    {
      yield return new WaitForSeconds(1.5f);
      GM.timeOn = true;
      Object.Destroy(this.gameObject);
    }
    IEnumerator shortDelay()
    {
      yield return new WaitForSeconds(0.2f);
      source.PlayOneShot(winClip);
    }

    // Update is called once per frame
    void Update()
    {
      if (!(currentArrowNum < ARROW_LIMIT) && !gameOver) {
        Debug.Log("You win!");
        gameOver = true;
        StartCoroutine(shortDelay());
        Object.Destroy(currentArrow.gameObject);
        StartCoroutine(ddrExit());
      }

      if (currentArrow.gameObject != null) {
        isInBox = currentArrowCollider == Physics2D.OverlapArea(inputBoxCollider.bounds.min, inputBoxCollider.bounds.max, LayerMask.GetMask("Box0"));
        isInKillBox = currentArrowCollider == Physics2D.OverlapArea(killCollider.bounds.min, killCollider.bounds.max, LayerMask.GetMask("Box0"));
        if (isInKillBox) {
          source.PlayOneShot(failNotes[currentArrowNum]);
          Object.Destroy(currentArrow.gameObject);
          Debug.Log("You lose!");
          StartCoroutine(ddrExit());
        }
        if (isInBox && Input.GetKeyDown(keyCodes[directionNum])) {
          source.PlayOneShot(successNotes[currentArrowNum]);
          Object.Destroy(currentArrow.gameObject);
          currentArrowNum += 1;
          newArrow();
        } else if (Input.GetKeyDown(keyCodes[0]) ||
                   Input.GetKeyDown(keyCodes[1]) ||
                   Input.GetKeyDown(keyCodes[2]) ||
                   Input.GetKeyDown(keyCodes[3])) {
          source.PlayOneShot(failNotes[currentArrowNum]);
          Object.Destroy(currentArrow.gameObject);
          Debug.Log("You lose!");
          StartCoroutine(ddrExit());

        }
        currentArrow.transform.Translate(Vector2.down * MOVE_SPEED * Time.deltaTime);
      }
    }
}
