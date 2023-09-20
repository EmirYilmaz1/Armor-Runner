using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideUI : MonoBehaviour
{
    Slider slider;
    Power power;
    void Start()
    {
        slider = GetComponent<Slider>();
       power = FindObjectOfType<Power>(); 
       power.OnLevelChange += ChangeSlider;
    }

    // Update is called once per frame
    void ChangeSlider()
    {
        slider.value = power.PowerLevel();
    }
}
