using System.Collections;
using UnityEngine;

public class Fighter : MonoBehaviour 
{
    int damage;
    Boss boss;
    Animator animator;
    private void Start() 
    {
       damage = GetComponent<Power>().CharacterType().damage;
        boss = FindObjectOfType<Boss>();
        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            boss.DecreaseHealt(damage);
            StartCoroutine(attackAnimation());        
        }    
    }

    IEnumerator attackAnimation()
    {   
        foreach(Transform animators in transform)
        {
           Animator animator= animators.GetComponent<Animator>();
            if(animator !=null)
            animator.SetBool("isAttacking", true);
        }
        
        yield return new WaitForSecondsRealtime(1f);
        foreach(Transform animators in transform)
        {
           Animator animator= animators.GetComponent<Animator>();
            if(animator !=null)
            animator.SetBool("isAttacking", false);
        }
        

    }
}