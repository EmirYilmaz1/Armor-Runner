using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineWalkCamera;
    [SerializeField] CinemachineVirtualCamera cinemachineFightCamera;

    [SerializeField] GameObject fightCanvas;

    private Fighter fighter;
    private PlayerMovement playerMovement;
    private Canvas sliderCanvas;
    private void Awake() 
    {
        fighter = GetComponent<Fighter>();
        playerMovement = GetComponent<PlayerMovement>();
        sliderCanvas = GetComponentInChildren<Canvas>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Finish"))
        {
          cinemachineWalkCamera.Priority = 11;
          playerMovement.SetFalse();
          Destroy(sliderCanvas.gameObject);
        }  

        if(other.gameObject.CompareTag("Fight"))
        {
            playerMovement.enabled = false;
            GetComponentInChildren<Animator>().SetBool("isIdle", true);
            StartCoroutine(FightSqeunce());
        }
    }

    private IEnumerator FightSqeunce()
    {
        cinemachineFightCamera.Priority = 15;
        yield return new WaitForSecondsRealtime(2f);
        fightCanvas.SetActive(true);
        fighter.enabled = true;
        FindObjectOfType<Boss>().canFight = true;
    }
}
