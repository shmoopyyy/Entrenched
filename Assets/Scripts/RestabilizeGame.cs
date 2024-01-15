using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestabilizeGame : MonoBehaviour
{
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
      
  }

  // Update is called once per frame
  void Update()
  {
    // overlaps = Physics2D.OverlapAreaAll();
    bool box0, box1, box2 = false;

    box0 = boxCollider0 == Physics2D.OverlapArea(slotCollider0.bounds.min, slotCollider0.bounds.max, LayerMask.GetMask("Box0"));
    box1 = boxCollider1 == Physics2D.OverlapArea(slotCollider1.bounds.min, slotCollider1.bounds.max, LayerMask.GetMask("Box1"));
    box2 = boxCollider2 == Physics2D.OverlapArea(slotCollider2.bounds.min, slotCollider2.bounds.max, LayerMask.GetMask("Box2"));
    if (box0 && box1 && box2) {
      Debug.Log("You win!");
    }
      
  }
}
