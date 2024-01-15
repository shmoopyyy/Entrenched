using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestabilizeGame : MonoBehaviour
{
  public AudioSource source;
  public AudioClip[] clips;
  public AudioClip winClip;
  public BoxCollider2D slotCollider0;
  public BoxCollider2D slotCollider1;
  public BoxCollider2D slotCollider2;

  public BoxCollider2D boxCollider0;
  public BoxCollider2D boxCollider1;
  public BoxCollider2D boxCollider2;

  private Collider2D[] overlaps;
  // Start is called before the first frame update
  void Start()
  {
    source = gameObject.GetComponent<AudioSource>();

  }

  private bool solved0;
  private bool solved1;
  private bool solved2;
  // Update is called once per frame
  IEnumerator boxesWin()
  {
    // while (source.isPlaying){
    //   yield return null;
    // }
    yield return new WaitForSeconds(1.5f);
    Debug.Log("End minigame");
    Object.Destroy(this.gameObject);
  }

  void Update()
  {
    // overlaps = Physics2D.OverlapAreaAll();
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
