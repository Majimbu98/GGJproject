using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Init

    Rigidbody rb;
    CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask ice;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float movementSpeed = 6f;
    float groundMovementSpeed;
    float airMovementSpeed;
    int contJump=0;

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 1f, ground);
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
        airMovementSpeed = movementSpeed / 2;
        groundMovementSpeed = movementSpeed;
        
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        // Movimento Rispetto Alla Telecamera

        float playerHorizontalInput = Input.GetAxis("Horizontal");
        float playerVerticalInput = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeVerticalInput = playerHorizontalInput * right;
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;
        cameraRelativeMovement.Normalize();


        //Salto Caricato - Contatore su fixedUpdate 
        if (Input.GetKey("space"))
        {
            contJump++;
            if (contJump >= 43 && ( IsGrounded() || IsOnIce() ))
            {
                rb.AddForce(Vector3.up * jumpForce * 1.5F, ForceMode.Impulse);
                contJump = 0;
            }
        }

        movementSpeed = IsGrounded() ? groundMovementSpeed : airMovementSpeed;

        //Applicazione Movimento
        rb.AddRelativeForce(cameraRelativeMovement*movementSpeed);
    }

    void Update()
    {

        //Salto normale
        if (Input.GetKeyUp("space") && (IsGrounded() || IsOnIce()))
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            contJump = 0;
        }

    }

 }

//Componenti Slide Su Ghiacchio
//float slidingHorizontally = 0;
//float slidingVertically = 0;

/*
if (IsOnIce)
{
    if (horizontalInput < slidingHorizontally)
    {

    }
    else
        slidingHorizontally = horizontalInput;        }
else
if (IsOnIce())
{
    if (playerHorizontalInput != 0 || playerVerticalInput != 0)
    {
        rb.velocity = new Vector3(playerHorizontalInput * movementSpeedOnIce, rb.velocity.y, playerVerticalInput * movementSpeedOnIce);
        slidingHorizontally = playerHorizontalInput * movementSpeedOnIce;
        slidingVertically = playerVerticalInput * movementSpeedOnIce;
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
*/
