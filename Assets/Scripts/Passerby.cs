using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passerby : MonoBehaviour
{
  [SerializeField]
  private Renderer spriteRenderer;
  // Start is called before the first frame update
  void Start()
  {
    // private GameManager GM = GameManager.instance;
    Debug.Log(GameManager.instance.msg);

  }

  // Update is called once per frame
  void Update()
  {
      
  }
}
