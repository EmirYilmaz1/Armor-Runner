using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Action OnHealtChange;
    public int healt = 100;
    public bool canFight;
    public bool isAttacking = true;

    private Animation animation;
    private PlayerHealth playerHealth;
    
    private void Awake()
    {
        animation = GetComponent<Animation>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        isAttacking = true;
    }
    private void Update() 
    {
        if(canFight&&isAttacking)
        {
            animation.Play();
            isAttacking = false;
        }
        
    }

    public void DecreaseHealt(int amount)
    {
        healt -= amount;
        OnHealtChange?.Invoke();
        if(healt<0)
        {
            Destroy(gameObject);
        }
    }

    public void Attack()
    {
        playerHealth.DecreaseHealth(15);
        isAttacking = true;
    }
}
