using System.Collections;
using UnityEngine;

public class Fighter : MonoBehaviour 
{
    private int damage;
    private Boss boss;
    private Animator animator;
    private bool canAttack = true;

    private void Start() 
    {
        damage = GetComponent<PowerManager>().CharacterType().damage;
        boss = FindObjectOfType<Boss>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0)&&canAttack)
        {
            StartCoroutine(attackAnimation());        
        }    
    }

    IEnumerator attackAnimation()
    {   
 
        animator.SetBool("isAttacking", true);
        canAttack = false;
        yield return new WaitForSecondsRealtime(.6f);
        Attack();
        yield return new WaitForSecondsRealtime(1.2f);
        canAttack = true;
        animator.SetBool("isAttacking", false);
        
    }

    //animation
    public void Attack()
    {
        boss.DecreaseHealt(damage);
    }
}