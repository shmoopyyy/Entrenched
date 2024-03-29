using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestabilizeGame : MonoBehaviour
{
  public const float STABILITY_REWARD = 20;
  public AudioSource source;
  public AudioClip[] clips;
  public AudioClip winClip;
  public BoxCollider2D slotCollider0;
  public BoxCollider2D slotCollider1;
  public BoxCollider2D slotCollider2;

  public BoxCollider2D boxCollider0;
  public BoxCollider2D boxCollider1;
  public BoxCollider2D boxCollider2;
  public GameObject[] boxes;
  public GameObject background;

  private GameManager GM;
  // Start is called before the first frame update
  void Start()
  {
    GM = GameManager.instance;
    source = gameObject.GetComponent<AudioSource>();
    Bounds bgBounds = background.GetComponent<BoxCollider2D>().bounds;
    for (int i = 0; i < boxes.Length; i++) {
      float x = Random.Range(bgBounds.min.x, bgBounds.max.x);
      float y = Random.Range(bgBounds.min.y, bgBounds.max.y);
      float z = boxes[i].transform.position.z;
      Debug.Log("Random position for box " + i + ", (" + x + ", " + y + ", " + z + ")");
      Vector3 bgOffset = background.transform.position / background.transform.localScale.x;
      bgOffset.z = 0;
      Debug.Log("bg position: " + bgOffset);

      boxes[i].transform.position = new Vector3(x, y, z) + bgOffset;
    }

  }

  private bool solved0;
  private bool solved1;
  private bool solved2;
  // Update is called once per frame
  IEnumerator boxesWin()
  {
    yield return new WaitForSeconds(1.5f);
    Debug.Log("End minigame");
    replenishStability();
    Object.Destroy(this.gameObject);
  }

  void replenishStability()
  {
    GM.stability = Mathf.Min(GM.stability + STABILITY_REWARD, GameManager.STABILITY_LIMIT);
  }

  void Update()
  {
    bool box0, box1, box2 = false;

    box0 = boxCollider0 == Physics2D.OverlapArea(slotCollider0.bounds.min, slotCollider0.bounds.max, LayerMask.GetMask("Box0"));
    box1 = boxCollider1 == Physics2D.OverlapArea(slotCollider1.bounds.min, slotCollider1.bounds.max, LayerMask.GetMask("Box1"));
    box2 = boxCollider2 == Physics2D.OverlapArea(slotCollider2.bounds.min, slotCollider2.bounds.max, LayerMask.GetMask("Box2"));

    if (box0 && !solved0) {
      Debug.Log("solved box 0");
      int soundIndex = Random.Range(0, clips.Length);
      source.PlayOneShot(clips[soundIndex]);
    }

    if (box1 && !solved1) {
      Debug.Log("solved box 1");
      int soundIndex = Random.Range(0, clips.Length);
      source.PlayOneShot(clips[soundIndex]);
    }

    if (box2 && !solved2) {
      Debug.Log("solved box 2");
      int soundIndex = Random.Range(0, clips.Length);
      source.PlayOneShot(clips[soundIndex]);
    }

    if (box0 && box1 && box2 && (!solved0 || !solved1 || !solved2)) {
      Debug.Log("You win!");
      source.PlayOneShot(winClip);
      StartCoroutine(boxesWin());
    }

    solved0 = box0;
    solved1 = box1;
    solved2 = box2;
    if(Input.GetKeyDown(KeyCode.P)) {
      Debug.Log("solved0: " + solved0);
      Debug.Log("solved1: " + solved1);
      Debug.Log("solved2: " + solved2);
      Debug.Log("box0: " + box0);
      Debug.Log("box1: " + box1);
      Debug.Log("box2: " + box2);
    }
  }
}
