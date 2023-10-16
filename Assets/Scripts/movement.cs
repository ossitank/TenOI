using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    private Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");    //A and D which are left and right strafes.
        float verticalInput = Input.GetAxis("Vertical");        //W and S are forward and back respectively.
        
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){    //Checks if grounded, if so then we jump
            rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse); //Jump
        }


    }

    bool IsGrounded(){
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f);
    }
}