using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvas : MonoBehaviour
{
    private void Awake() 
    {
        FindObjectOfType<CollisionHandler>().OnFightSequnce += () => {GetComponent<Canvas>().enabled=true;};    
    }
}
