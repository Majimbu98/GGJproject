
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
    int contJump = 0;
    int timeWait = 0;
    bool isStun = false;
    [SerializeField] float maxspeed = 9f;

    IEnumerator WaitStun()
    {
        yield return new WaitForSeconds(5f);
        isStun = false;
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(rb.position, groundCheck.position, 0.1f, ground);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bee")
        {
            isStun = true;

            StartCoroutine(WaitStun());

        }
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
        if (Input.GetKey("space") && isStun == false)
        {
            contJump++;
            if (contJump >= 43 && (IsGrounded() || IsOnIce()))
            {
                rb.AddForce(Vector3.up * jumpForce * 1.5F, ForceMode.Impulse);
                contJump = 0;
            }
        }

        movementSpeed = IsGrounded() ? groundMovementSpeed : airMovementSpeed;

        //Applicazione Movimento
        if (isStun == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            rb.AddRelativeForce(cameraRelativeMovement * movementSpeed);
        }
    }

    void Update()
    {
        if (rb.velocity.magnitude>maxspeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);
        }


        //Salto normale
        if (Input.GetKeyUp("space") && (IsGrounded() || IsOnIce()) && isStun == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            contJump = 0;
        }

    }

}