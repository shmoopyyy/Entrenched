using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
  public float speed;

  [SerializeField]
  private Renderer bgRenderer;
  private GameManager GM;

  void Start()
  {
    GM = GameManager.instance;
  }
  // Update is called once per frame
  void Update()
  {
    if (GM.timeOn) {
      bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
      
  }
}
