using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePasserby : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float leftBound = -6;
    public float moveSpeed = 5;
    // Update is called once per frame
    void Update()
    {
      float currPos = transform.position.x;
      if (currPos >= leftBound) {
        transform.Translate(Vector2.left *moveSpeed * Time.deltaTime);
      } else {
        Debug.Log(currPos);
      }

      // if (Input.GetKey(KeyCode.LeftArrow)) {
      //   transform.Translate(Vector2.left *moveSpeed * Time.deltaTime);
      // } else if (Input.GetKey(KeyCode.RightArrow)) {
      //   transform.Translate(Vector2.right *moveSpeed * Time.deltaTime);
      // } else if (Input.GetKey(KeyCode.UpArrow)) {
      //   transform.Translate(Vector2.up *moveSpeed * Time.deltaTime);
      // } else if (Input.GetKey(KeyCode.DownArrow)) {
      //   transform.Translate(Vector2.down *moveSpeed * Time.deltaTime);
      // }
    }
}
