using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform mesh;
    public Rigidbody rb;

    public float rotationSpeed;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update(){

        //rotate oritentation:
        Vector3 viewerDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewerDir.normalized;

        //rotate player:
        float horizontalInput = Input.GetAxis("Horizontal");    //A and D which are left and right strafes.
        float verticalInput = Input.GetAxis("Vertical");        //W and S are forward and back respectively.
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        if(inputDir != Vector3.zero)
        {
            player.forward = Vector3.Slerp(mesh.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

    }
}