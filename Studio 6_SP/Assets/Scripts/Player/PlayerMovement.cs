using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    float speed = 6f;
    float runSpeed = 20f;
    float jumpHeight = 2f;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    float gravity = -20f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // -1 if a key, +2 if d key
        float vertical = Input.GetAxisRaw("Vertical");  // -1 if s key, +2 if w key
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        /*      Jump      */
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //checks if groundcheck sphere is in contact with object labelled ground

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //direction = new Vector3(horizontal, jumpHeight, vertical);
            //controller.Move(direction * speed * Time.deltaTime);
        }

        

        /*      0000        */
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //smooths character turning
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        
        /*      Sprint        */
        if(Input.GetKeyDown(KeyCode.LeftShift)) speed = runSpeed;
        if(Input.GetKeyUp(KeyCode.LeftShift)) speed = 6f;
        
    }
}
