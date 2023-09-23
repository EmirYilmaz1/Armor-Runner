using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    public event  Action OnWalkSequence;
    public  event Action OnFightSequnce;


    [SerializeField] private Fighter fighter;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            WalkingSequence();
        }

        if (other.gameObject.CompareTag("Fight"))
        {
            StartCoroutine(FightSequence());
        }
    }

    private void WalkingSequence()
    {
        OnWalkSequence?.Invoke();
    }

    private IEnumerator FightSequence()
    {

        yield return new WaitForSecondsRealtime(2f);
        OnFightSequnce?.Invoke();
        GetComponentInChildren<Animator>().SetBool("isIdle", true);
        fighter.enabled = true;
    }
}
