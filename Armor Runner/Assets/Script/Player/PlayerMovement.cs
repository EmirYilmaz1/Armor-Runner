using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;

    private bool canMove = true;
    private Rigidbody rb;
    private Vector3 mousePos;
    private CollisionHandler collisionHandler;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collisionHandler = GetComponent<CollisionHandler>();
        collisionHandler.OnWalkSequence += StopMoving;
        collisionHandler.OnFightSequnce += () => {this.enabled = false;};
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*forwardSpeed);
        if(Input.GetMouseButton(0)&&canMove)
        {
            mousePos = Input.mousePosition;
            float pos  = (mousePos.x-524)/524;
            rb.velocity = new Vector3 (pos*horizontalSpeed,0,0);
        }
    }

    public void StopMoving()
    {
        canMove = false;
    }
}
