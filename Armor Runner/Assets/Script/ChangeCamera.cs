using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] bool isFighCamera;
    CollisionHandler collisionHandler; 
    void Start()
    {
        collisionHandler = FindObjectOfType<CollisionHandler>();
        if(isFighCamera)
        {
            collisionHandler.OnFightSequnce +=  () => {GetComponent<CinemachineVirtualCamera>().Priority = 17;};
        }
        else
        {
            collisionHandler.OnWalkSequence += () => {GetComponent<CinemachineVirtualCamera>().Priority = 15;};
        }
        
    }
}
