using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Animation animation;
    private PlayerHealth playerHealth;
    
    private void Awake()
    {
        animation = GetComponent<Animation>();
        FindObjectOfType<CollisionHandler>().OnFightSequnce += () =>{  playerHealth = FindObjectOfType<PlayerHealth>(); animation.Play();}; 
    }
    public void Attack()
    {
        playerHealth.DecreaseHealth(10);
    }

}
