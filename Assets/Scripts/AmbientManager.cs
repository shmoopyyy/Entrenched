using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientManager : MonoBehaviour
{
  public static AmbientManager instance;

  public string spritePath = "background_sprites";
  private Sprite[] treeSprites;
  private Sprite[] bgSprites;
  private int num_sprites_fg;
  private int num_sprites_bg;
  public BGPasserby prefabBGPasserby;
  public FGPasserby prefabFGPasserby;

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
    treeSprites = Resources.LoadAll<Sprite>(spritePath+"/trees");
    bgSprites = Resources.LoadAll<Sprite>(spritePath+"/background");
    num_sprites_fg = treeSprites.Length;
    num_sprites_bg = bgSprites.Length;
    Debug.Log("there are " + num_sprites_fg + " foreground sprites loaded.");
    Debug.Log("there are " + num_sprites_bg + " background sprites loaded.");
      
  }

  // Update is called once per frame
  void Update()
  {
    // If time for a new NPC, clone one from template and fill in details
    if (Input.GetKeyDown(KeyCode.Return)) {
      if (Random.Range(0,2) == 0) {
        int sprite_version = Random.Range(0, num_sprites_fg);
        FGPasserby newPasserby;
        newPasserby = Instantiate(prefabFGPasserby);
        newPasserby.spriteRenderer.sprite = treeSprites[sprite_version];
        newPasserby.movementOn = true;
      } else {
        int sprite_version = Random.Range(0, num_sprites_bg);
        BGPasserby newPasserby;
        newPasserby = Instantiate(prefabBGPasserby);
        newPasserby.spriteRenderer.sprite = bgSprites[sprite_version];
        newPasserby.movementOn = true;

      }

    }

  }
}
