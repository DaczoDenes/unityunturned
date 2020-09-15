using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meggy : MonoBehaviour
{
    
    public CharacterController controller;

    public float speed = 10;
    public float gravity = -9.81f;
    public float jumpHeight = 0.01f;

    public Transform  groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    


    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        
        
        if (isGrounded){
            
            if (Input.GetKeyDown(KeyCode.LeftShift)){
                transform.localScale = new Vector3(1, 0.5f, 1);
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
                speed = speed / 1.5;
            }
        
            if (Input.GetKeyUp(KeyCode.LeftShift)){
                transform.localScale = new Vector3(1, 1f, 1);
            
                speed = 10;
            
            }

        }
        

        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;  

        
        

        Vector3 move = transform.right * x + transform.forward * z;

        
        

        controller.Move(move * Time.deltaTime );


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    






}
