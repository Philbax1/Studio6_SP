using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController controller;
    public Rigidbody charRigidbody;
    public Transform cam;

    float activeSpeed;
    const float speed = 6f;
    float runSpeed = 20f;
    float jumpHeight = 2f;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

// Jump variables
    float gravity = -20f;
    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool canDoubleJump = true;

// Water variables
    public LayerMask waterMask;
    public Transform waterCheck;

    bool isInWater;

    // Start is called before the first frame update
    void Start()
    {
        activeSpeed = speed;
        charRigidbody = GetComponent<Rigidbody>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Screen.lockCursor = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) Debug.Log("Move");

        float horizontal = Input.GetAxisRaw("Horizontal");  // -1 if a key, +2 if d key
        float vertical = Input.GetAxisRaw("Vertical");  // -1 if s key, +2 if w key
        Vector3 direction = transform.position + transform.forward * vertical + transform.right * horizontal * speed * Time.deltaTime;

        charRigidbody.MovePosition(direction);

        /*      Jump      */
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //checks if groundcheck sphere is in contact with object labelled ground

        if(isGrounded && velocity.y < 0) // stops gravity when player is on ground again
        {
            velocity.y = -2f;
            canDoubleJump = true;   //allows player to double jump after makiing contact with ground layer
        }

        //velocity.y += gravity * Time.deltaTime;
        //charRigidbody.MovePosition(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded) 
            {
                activeSpeed = speed;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // physical jump code
            }
            else if(canDoubleJump)
            {
                activeSpeed = speed;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // physical jump code
                canDoubleJump = false;
            }
        }
        

        /*      snap to camera        */
        if(direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //smooths character turning
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            charRigidbody.MoveRotation(moveDir.normalized * activeSpeed * Time.deltaTime);
        }

        
        /*      Sprint        */
        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded) activeSpeed = runSpeed;
        if(Input.GetKeyUp(KeyCode.LeftShift)) activeSpeed = speed;
    }
}