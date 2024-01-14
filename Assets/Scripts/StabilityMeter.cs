using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StabilityMeter : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private GameManager GM;

    public void SetMaxStability(int stability)
    {
        slider.maxValue = stability;
        slider.value = stability;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetStability(int stability)
    {
      if (stability > GameManager.STABILITY_LIMIT) {
        slider.value = (int)GameManager.STABILITY_LIMIT;
      } else if (stability < 0) {
        slider.value = 0;
      } else {
        slider.value = stability;
      }
      fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Start()
    {
      GM = GameManager.instance;
      SetMaxStability(GameManager.STABILITY_LIMIT);
    }
    void Update()
    {
      SetStability((int)GM.stability);
      if(Input.GetKeyDown(KeyCode.UpArrow)) {
        GM.stability = Mathf.Min(GM.stability + 20, GameManager.STABILITY_LIMIT);
        SetStability((int)GM.stability);
      }
      if(Input.GetKeyDown(KeyCode.DownArrow)) {
        GM.stability = Mathf.Max(GM.stability - 20, 0);
        SetStability((int)GM.stability);
      }
    }
}