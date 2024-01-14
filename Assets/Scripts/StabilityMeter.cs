using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StabilityMeter : MonoBehaviour
{
    public Slider slider;


    public void SetMaxStability(int stability)
    {
        slider.maxValue = stability;
        slider.value = stability;
    }
    public void SetStability(int stability)
    {
        slider.value = stability;
    }
}