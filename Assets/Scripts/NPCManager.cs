using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
  public static NPCManager instance;

  /* Sprite parameters */

  public string spritePath = "passerby_sprites";
  private Sprite[] sprites;
  public int sprite_version;
  private int num_sprites;
  public Passerby prefabPasserby;
  
  public static bool passerbyPresent = false;
  public const float MAX_GEN_OFFSET = 1f;
  private float genOffset;

  private GameManager GM;
  void Awake()
  {
    // Initialize Singleton instance
    if (instance == null) {
      instance = this;
    }
  }

  // Start is called before the first frame update
  void Start()
  {
    // Read in question/answer data from file, store in private? attribute

    // initialize set of allowable skins
    GM = GameManager.instance;
    sprites = Resources.LoadAll<Sprite>(spritePath);
    num_sprites = sprites.Length;
    Debug.Log("there are " + num_sprites + " sprites loaded.");
      
  }

  IEnumerator summon()
  {
    Debug.Log("summoning...");
    genOffset = Random.Range(0, MAX_GEN_OFFSET);
    yield return new WaitForSeconds(genOffset);

    sprite_version = Random.Range(0, num_sprites);
    Passerby newPasserby;
    newPasserby = Instantiate(prefabPasserby);
    newPasserby.spriteRenderer.sprite = sprites[sprite_version];
  }

  // Update is called once per frame
  void Update()
  {
    if (GM.timeOn) {
      // If time for a new NPC, clone one from template and fill in details
      if (!passerbyPresent) {
        passerbyPresent = true;
        StartCoroutine(summon());
      } 

    }

  }
}
