using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager GM;
    public TMPro.TextMeshProUGUI textMeshPro;
    void Start()
    {
      GM = GameManager.instance;

    }

    // Update is called once per frame
    void Update()
    {
      textMeshPro.text = GM.distance.ToString();

    }
}
