using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public CharacterController controller;
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

    [SerializeField] LineRenderer lineRend;

    Vector3 velocity;
    bool isGrounded;
    bool canDoubleJump = true;

    public GameObject waterObject;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        activeSpeed = speed;
        waterObject = GameObject.FindGameObjectWithTag("waterPlane");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Screen.lockCursor = true;
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // -1 if a key, +2 if d key
        float vertical = Input.GetAxisRaw("Vertical");  // -1 if s key, +2 if w key
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        /*      Jump      */
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //checks if groundcheck sphere is in contact with object labelled ground

        if(isGrounded && velocity.y < 0) // stops gravity when player is on ground again
        {
            velocity.y = -2f;
            canDoubleJump = true;   //allows player to double jump after makiing contact with ground layer
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        jumpGroundHelper();

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

        cameraSnap(direction);

        /*      snaps player to camera direction         */
        
        
        /*      Sprint        */
        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded) activeSpeed = runSpeed;
        if(Input.GetKeyUp(KeyCode.LeftShift)) activeSpeed = speed;
    }

    public void jumpGroundHelper()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (!isGrounded)
            {
                lineRend.enabled = true;
                lineRend.SetPosition(0, transform.position);
                lineRend.SetPosition(1, hit.point);
            }
            else
            {
                lineRend.enabled = false;
            }
        }  
    }

    public void cameraSnap(Vector3 direction)
    {
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //smooths character turning
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * activeSpeed * Time.deltaTime);
        }

    }
}