using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject gun;
    public GameObject body;
    public float speedx;
    public float speedy;
    public float runSpeed = 3f;
    public float crouchSpeed = 0f;
    public float jumpForce = 600f;
    public float slideForce = 400f;
    bool crouch = false;
    public bool speedMode = false;
    public float turbo = 2f;

    public Rigidbody rb;

    // ground check
    public Transform  groundCheck;
    public float groundDistance = 0.4f;
    public bool grounded;
    public LayerMask ground;

    void Update()
    {
        gun.transform.position(body.transform.position.x - 2, body.transform.position.y, body.transform.position.z)
        
        //SPEED MODE
        if(speedMode == false){
            turbo = 1;
        }
        // GROUND CHECK

        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        // CROUCH

        if (Input.GetKeyDown(KeyCode.LeftShift)){
                transform.localScale = new Vector3(1, 0.5f, 1);
                if (crouch == false){
                    if (Input.GetAxisRaw("Horizontal") == -1){
                    rb.AddForce(transform.right * -slideForce);    
                    }
                    if (Input.GetAxisRaw("Horizontal") == 1){
                    rb.AddForce(transform.right * slideForce);    
                    } 
                    if (Input.GetAxisRaw("Vertical") == -1){
                    rb.AddForce(transform.forward * -slideForce);    
                    } 
                    if (Input.GetAxisRaw("Vertical") == 1){
                    rb.AddForce(transform.forward * slideForce);    
                    }                  
                }
                crouch = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)){
                transform.localScale = new Vector3(1, 1f, 1);
                crouch = false;
            }
        // MOVE

        // x
        if (Input.GetAxisRaw("Horizontal") == -1){
            if (crouch){
                speedx = -crouchSpeed; 
            }  
            else{
                speedx = -runSpeed;
            }    
        }    
        else if (Input.GetAxisRaw("Horizontal") == 1){
            if (crouch){
                speedx = crouchSpeed; 
            }  
            else{
                speedx = runSpeed;
            } 
        }
        else{
            speedx = 0;
        }

        // y

        if (Input.GetAxisRaw("Vertical") == -1){
            if (crouch){
                speedy = -crouchSpeed; 
            }  
            else{
                speedy = -runSpeed;
            } 
        }
        else if (Input.GetAxisRaw("Vertical") == 1){
            if (crouch){
                speedy = crouchSpeed; 
            }  
            else{
                speedy = runSpeed;
            } 
        }
        else{
            speedy = 0;
        }

        // move
        
        float x = Input.GetAxisRaw("Horizontal") + speedx * turbo;
        float z = Input.GetAxisRaw("Vertical") + speedy * turbo;

        Vector3 move = transform.right * x + transform.forward * z;

        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);

        // JUMP
        if(Input.GetButtonDown("Jump") && speedMode){
            rb.AddForce(transform.up * jumpForce * turbo);
        }
        else if (Input.GetButtonDown("Jump") && grounded){
            rb.AddForce(transform.up * jumpForce);
        }
    }
}
