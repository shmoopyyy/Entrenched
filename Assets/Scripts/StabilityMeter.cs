using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StabilityMeter : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxStability(int stability)
    {
        slider.maxValue = stability;
        slider.value = stability;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetStability(int stability)
    {
        slider.value = stability;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}