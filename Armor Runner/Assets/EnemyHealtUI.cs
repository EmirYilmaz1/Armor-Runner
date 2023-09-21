using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealtUI : MonoBehaviour
{   
    Slider slider;
    Boss boss;
    void Start()
    {
       slider = GetComponent<Slider>();
       boss =FindObjectOfType<Boss>();
       SetBar();
       boss.OnHealtChange += () => { slider.value = boss.healt;};
    }

    void SetBar()
    {
        slider.maxValue =boss.healt;
        slider.value = boss.healt;
    }


}
