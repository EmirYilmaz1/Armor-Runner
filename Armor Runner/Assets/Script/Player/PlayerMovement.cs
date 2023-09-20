using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
        if(Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            float pos  = (mousePos.x-524)/524;
            transform.position= new Vector3(pos*speed,transform.position.y,transform.position.z);
        }
    }
}
