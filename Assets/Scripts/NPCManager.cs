using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
  public static NPCManager instance;
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
        
    }

    // Update is called once per frame
    void Update()
    {
      // If time for a new NPC, clone one from template and fill in details
      
    }
}
