using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnPlayerHealtChange;
    public int playerMaxHealth;
    public int playerCurrentHealth;

    PowerManager power;
    CharacterType characterType;
    void Start()
    {
        power = gameObject.GetComponent<PowerManager>();
        SetHealt();
        power.OnCharacterChange += SetHealt;
    }


    // Change when Character Change
    void SetHealt()
    {
        playerMaxHealth = power.CharacterType().healt;
        playerCurrentHealth = playerMaxHealth;
    }

    public void DecreaseHealth(int amount)
    {
        playerCurrentHealth -= amount;
        OnPlayerHealtChange?.Invoke();
    }
}
