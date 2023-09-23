using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{   
    Slider slider;
    BossHealth bossHealt;
    void Start()
    {
       slider = GetComponent<Slider>();
       bossHealt = FindObjectOfType<BossHealth>();
       SetBar();
       bossHealt.OnHealtChange += () => { slider.value = bossHealt.BossCurrentHealt();};
    }

    void SetBar()
    {
        slider.maxValue = bossHealt.BossCurrentHealt();
        slider.value = bossHealt.BossCurrentHealt();
    }


}
