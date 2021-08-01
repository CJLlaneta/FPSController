using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
   
    public float Speed = 12f; //Character Movement Speed Can be change in the inspector
    public float Gravity = 10; //Force of gravity


    CharacterController controller;
    void Start()
    {
        //Getting the character controller component from FPS Controller object
        controller = gameObject.GetComponent<CharacterController>();
    }

  
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CharacterMovement();
    }

    private void CharacterMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        if (!controller.isGrounded)
        {
            move += Vector3.up * -Gravity; //This will serve as the gravity
        }

        controller.Move(move * Speed * Time.deltaTime); //this is to move the character
    }
}
