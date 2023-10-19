using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Grounded")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    private void Start(){
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update(){
        //Checks if grounded
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        //Handles player movement
        MyInput();
        SpeedControl();
        //Handle drag:
        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void MyInput()
    {
        //Keyboard input:
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {   //Movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        rb.AddForce(moveDirection.normalized*moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; // Calculates max velocity
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); //Applies it to character
        }
    }
}