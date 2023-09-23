using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<CollisionHandler>().OnWalkSequence += () =>{Destroy(gameObject);};
    }
}
