using System.Collections;
using UnityEngine;

public class Fighter : MonoBehaviour 
{
    private int damage;
    private BossHealth bossHealth;
    private Animator animator;
    private bool isAttacking = false;

    private void Start() 
    {
        damage = GetComponent<PowerManager>().CharacterType().damage;
        bossHealth = FindObjectOfType<BossHealth>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0)&&!isAttacking)
        {
            StartCoroutine(AttackAnimation());        
        }    
    }

    IEnumerator AttackAnimation()
    {   
        animator.SetBool("isAttacking", true);
        isAttacking = true;
        yield return new WaitForSecondsRealtime(.6f);
        Attack();
        yield return new WaitForSecondsRealtime(1.2f);
        isAttacking = false;
        animator.SetBool("isAttacking", false);
    }

    public void Attack()
    {
        bossHealth.DecreaseHealt(damage);
    }
}