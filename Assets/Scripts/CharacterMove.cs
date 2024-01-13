using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

  public float width = 100;
  public float speed;

  [SerializeField]
  private Renderer charRenderer;

    // Update is called once per frame
    void Update()
    {
      float newPos = speed*Time.deltaTime % width;
      charRenderer.material.mainTextureOffset += new Vector2(newPos, 0);
    }
}
