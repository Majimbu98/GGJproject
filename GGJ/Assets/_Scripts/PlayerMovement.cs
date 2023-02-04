using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] float jumpForce = 5f;
    [SerializeField] float movementSpeed = 6f;

    int contatore=0;

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame

   
    void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            contatore++;
            if (contatore >= 43 && IsGrounded() == true)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce*1.3f, rb.velocity.z);
                contatore = 0;
            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

    }


    void Update()
    {
        

        if (Input.GetKeyUp("space") && IsGrounded() == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            contatore = 0;
        }

    }
}
