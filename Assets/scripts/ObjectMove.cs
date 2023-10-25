using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, verticalInput * speed);


        if(Input.GetButtonDown("Jump") && CheckIsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x,jumpForce,rb.velocity.z);
    }
    }

    //my own method
    bool CheckIsGrounded()
    {
       return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }


}
