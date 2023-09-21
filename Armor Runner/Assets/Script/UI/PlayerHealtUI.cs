using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealtUI : MonoBehaviour
{
    Slider slider;
    PlayerHealth playerHealth;
    void Start()
    {
      slider = GetComponent<Slider>();
      playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
      SetBar();
      playerHealth.OnPlayerHealtChange += () => {slider.value = playerHealth.playerCurrentHealth;};
    }

    void SetBar()
    {
        slider.maxValue = playerHealth.playerMaxHealth;
        slider.value = playerHealth.playerCurrentHealth;
    }
}
