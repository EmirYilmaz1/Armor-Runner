using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWave : MonoBehaviour
{
   [SerializeField] private Vector3 moveFactor;
    private Vector3 startPos;

    [SerializeField] private float speed = 2;
    private float cycle;
    private float tau;
    private float sin;
    private float fixedSin;

    void Start()
    {
        tau = Mathf.PI*2;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cycle = Time.time/speed;
        sin =  Mathf.Sin(cycle*tau);
        fixedSin = (sin+1)/2;
         Vector3 offset= moveFactor *fixedSin;
        transform.position = startPos + offset;
    }
}
