using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineWalkCamera;
    [SerializeField] CinemachineVirtualCamera cinemachineFightCamera;

    [SerializeField] GameObject canvas;

    Fighter fighter;
    PlayerMovement playerMovement;
    Canvas levelCanvas;
    Animator animator;
    private void Awake() 
    {
        fighter = GetComponent<Fighter>();
        playerMovement = GetComponent<PlayerMovement>();
        levelCanvas = GetComponentInChildren<Canvas>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Finish"))
        {
          cinemachineWalkCamera.Priority = 11;
          playerMovement.SetFalse();
          levelCanvas.enabled = false;
        }  

        if(other.gameObject.CompareTag("Fight"))
        {
            playerMovement.enabled = false;
            GetComponent<Animator>().SetBool("isIdle", true);

            foreach (Transform child in transform)
            {
                Animator childAnimator = child.GetComponent<Animator>();
                if (childAnimator != null)
                {
                    childAnimator.SetBool("isIdle", true);
                }
            }
            StartCoroutine(FightSqeunce());
        }
    }

    private IEnumerator FightSqeunce()
    {
        cinemachineFightCamera.Priority = 15;
        yield return new WaitForSecondsRealtime(2f);
        canvas.SetActive(true);
        fighter.enabled = true;
    }
}
