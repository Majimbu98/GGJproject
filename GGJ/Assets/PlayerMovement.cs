using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask ice;

    [SerializeField] float jumpForce = 5f;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float movementSpeedOnIce = 8f;
    float slidingHorizontally = 0;
    float slidingVertically = 0;

    int contatore=0;

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

    bool IsOnIce()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ice);
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
        //print("Ice "+IsOnIce());
        //print("Ground "+IsGrounded());
        if (Input.GetKey("space"))
        {
            contatore++;
            if (contatore >= 43 && ( IsGrounded() || IsOnIce() ))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce*1.3f, rb.velocity.z);
                contatore = 0;
            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        /*
        if (IsOnIce)
        {
            if (horizontalInput < slidingHorizontally)
            {

            }
            else
                slidingHorizontally = horizontalInput;        }
        else*/
        if (IsOnIce())
        {
            if (horizontalInput != 0 || verticalInput != 0)
            {
                rb.velocity = new Vector3(horizontalInput * movementSpeedOnIce, rb.velocity.y, verticalInput * movementSpeedOnIce);
                slidingHorizontally = horizontalInput * movementSpeedOnIce;
                slidingVertically = verticalInput * movementSpeedOnIce;
            }
            else if(slidingHorizontally!= 0 || slidingVertically!=0)
            {
                print(slidingHorizontally + " " + slidingVertically);
                if(Mathf.Abs(slidingHorizontally) < 0.05f || Mathf.Abs(slidingVertically) < 0.05f)
                {
                    slidingHorizontally = 0;
                    slidingVertically = 0;
                }
                rb.velocity = new Vector3(slidingHorizontally, rb.velocity.y, slidingVertically);
                //slidingHorizontally = slidingHorizontally / 1.1f;
                //slidingVertically = slidingVertically / 1.1f;
            }
        }
        else
        {
            rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
            
        }

    }


    void Update()
    {
        

        if (Input.GetKeyUp("space") && (IsGrounded() || IsOnIce()))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            contatore = 0;
        }

    }
}
