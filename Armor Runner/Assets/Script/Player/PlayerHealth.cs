using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnPlayerHealtChange;
    public int playerMaxHealth;
    public int playerCurrentHealth;

    Power power;
    CharacterType characterType;
    void Start()
    {
        power = gameObject.GetComponent<Power>();
        SetHealt();
        power.OnCharacterChange += SetHealt;
    }


    // Change when Character Change
    void SetHealt()
    {
        playerMaxHealth = power.CharacterType().healt;
        playerCurrentHealth = playerMaxHealth;
    }

    public void DecreaseHeal(int amount)
    {
        playerCurrentHealth -= amount;
        OnPlayerHealtChange?.Invoke();
    }
}
