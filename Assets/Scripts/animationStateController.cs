using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardKey = Input.GetKey(KeyCode.W); //Checks for w key input
        bool backwardKey = Input.GetKey(KeyCode.S); //Checks for s key input
        bool sprintKey = Input.GetKey(KeyCode.LeftShift); //Checks for shift key input
        bool strafeLeftKey = Input.GetKey(KeyCode.A);   //Left strafe
        bool strafeRightKey = Input.GetKey(KeyCode.D);  //Right strafe

        //Key input w starts a walking animation:
        if(forwardKey)
        {
            animator.SetBool("IsWalking", true);
        }

        if(!forwardKey) //Stop walking
        {
            animator.SetBool("IsWalking", false);
        }
    
        if(forwardKey && sprintKey) //Key input w and shift starts sprint animation:
        {
            animator.SetBool("IsRunning", true);
        }
        if(forwardKey && !sprintKey){
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsWalking", true);
        }
        if(!forwardKey && sprintKey)
        {
            animator.SetBool("IsRunning", false);
        }
        //Key input for strafing left and right:
        if(strafeLeftKey)
        {
            animator.SetBool("IsWalkingLeft", true);
        }

        if(!strafeLeftKey) //Stop walking
        {
            animator.SetBool("IsWalkingLeft", false);
        }

        if(strafeRightKey)
        {
            animator.SetBool("IsWalkingRight", true);
        }

        if(!strafeRightKey) //Stop walking
        {
            animator.SetBool("IsWalkingRight", false);
        }
    }
}
