using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public CharacterController controller;
    //public Rigidbody rb;

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

// swim float variables
    public LayerMask waterMask;
    public bool isSwimming = false;

    public float floatingPower = .1f;
    private float waterHeight = 29f; // This determines the water level

    bool underWater;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();

        groundMask = LayerMask.GetMask("Ground");
        waterMask = LayerMask.GetMask("Water");

        activeSpeed = speed;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;        
    }

    // Update is called once per frame
    void Update ()
    {
/*      Forward,back,left,right      */
        float horizontal = Input.GetAxisRaw("Horizontal");  // -1 if a key, +2 if d key
        float vertical = Input.GetAxisRaw("Vertical");  // -1 if s key, +2 if w key
        
        moveCharacter(horizontal, vertical);
          

/*      Sprint        */
        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded) activeSpeed = runSpeed;
        if(Input.GetKeyUp(KeyCode.LeftShift)) activeSpeed = speed;


/*      Jump      */
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //checks if groundcheck sphere is in contact with object labelled ground

        if(isGrounded && velocity.y < 0) // stops gravity when player is on ground again
        {
            velocity.y = -2f;
            canDoubleJump = true;   //allows player to double jump after makiing contact with ground layer
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded || isSwimming) 
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

        jumpGroundHelper();


/*      Swim        */
        swim();
    }

    public void moveCharacter(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        cameraSnap(direction); // method that moves character in camera direction
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
 
    public void swim() 
    {
        float differnce = transform.position.y - waterHeight;

        Debug.Log(differnce);

        if(differnce <= 0 && differnce <= 0.5)
        {
            isSwimming = true;
            velocity.y = Mathf.Sqrt(floatingPower * Time.deltaTime);

            Debug.Log("Swimming");
        }
        else if(differnce < 0.5)
        {
             //velocity.y = Mathf.Sqrt(floatingPower * Time.deltaTime);
        }
        else
        {
            isSwimming = false;
        }
    }
/*
    void switchState (bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airAngularDrag;
        }
    }
    */
}