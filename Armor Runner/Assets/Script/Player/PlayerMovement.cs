using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;

    private bool canMove = true;
    public void SetFalse()
    {
        canMove = false;
    }
    Rigidbody rigidbody;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*forwardSpeed);
        if(!canMove) return;
        if(Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            float pos  = (mousePos.x-524)/524;
            rigidbody.velocity = new Vector3 (pos*horizontalSpeed,0,0);
        }
    }
}
