using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Rendering;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerMovement instance;
    private Rigidbody rb;
    private Animator animator;
    
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpForce = 500f;

    public float leftRotation;
    public float rightRotation;

    private Vector3 jumpForceVector;
    public int jumpCount;
    public int jumpMax = 2;
    private float jumpDelay = 0.1f;

    Vector3 velocity;
    Vector3 airVelocity;

    public float Speed 
    {
        get {return speed;}
        private set {speed = value;}
    }

    public float Health {get; set;}
    public float Damage {get; set;}
    public float JumpForce 
    {
        get {return jumpForce;}
        private set {jumpForce = value;}
    }

    public bool isFacingRight = true;
    public bool isGrounded;
    public bool isAirborne;
    public float currentSpeed;
    public float bubbleFloat;
    public float gravity;



    void Awake() 
    {
        if (instance == null) {
            instance = this;
        }
    }
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        
    }

    private void FixedUpdate()
    {
        Vector3 customgravity = new Vector3(0, -9.81f * gravity, 0);
        rb.AddForce(customgravity, ForceMode.Acceleration);
    }

    void Update() {

        //FACE LEFT OR RIGHT//
        if (isFacingRight == true) {
            transform.eulerAngles = (new Vector3 (transform.rotation.x, rightRotation, transform.rotation.z));
        }
        else {
            transform.eulerAngles = (new Vector3 (transform.rotation.x, leftRotation, transform .rotation.z));
        }

        if (isGrounded) {
             StartCoroutine(ResetJump());
            
        }

        velocity = new Vector3 (speed, 0, 0);
        

        #region GroundedMovement

        if (Input.GetAxisRaw("Horizontal") < 0f && !isAirborne) {

            rb.velocity += (-velocity) * Time.deltaTime;
            isFacingRight = false;

        }

        if (Input.GetAxisRaw("Horizontal") > 0f && !isAirborne) {

            rb.velocity += (velocity) * Time.deltaTime;
            isFacingRight = true;
        }

        currentSpeed = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Run", Mathf.Abs(currentSpeed));

        #endregion


        airVelocity = new Vector3(speed / 5, 0, 0);

        #region AirborneMovement

        //Airborne, No block
        if (isAirborne && Input.GetAxisRaw("Horizontal") < 0f && !animator.GetBool("isBlocking")) {

            
            rb.velocity += (-airVelocity) * Time.deltaTime;
            isFacingRight = false;
        }

        //Airborne, No block
        if (isAirborne && Input.GetAxisRaw("Horizontal") > 0f && !animator.GetBool("isBlocking")) {

            rb.velocity += (airVelocity) * Time.deltaTime;
            isFacingRight = true;
        }

        //Airborne & blocking
        if (isAirborne && animator.GetBool("isBlocking"))
        {
            rb.velocity += new Vector3(speed * 0, 0);
            rb.AddForce(new Vector3(0f, bubbleFloat, 0));
        }

        //Grounded & blocking
        if (isGrounded && animator.GetBool("isBlocking"))
        {
            //rb.constraints = RigidbodyConstraints.FreezePosition;
        }

        else if (!animator.GetBool("isBlocking"))
        {
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        #endregion

        jumpForceVector = new Vector3 (0f, jumpForce, 0);
        
        #region Jump
        if (Input.GetButtonDown("Jump") && jumpCount < jumpMax)
        { 
            Jump();
        }

        if (Input.GetButtonUp("Jump")) {
            rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y / 2, 0);
        }

        if (Input.GetAxisRaw("Vertical") <= -0.5f && rb.velocity.y < 0) {
            FastFall();
        }
        #endregion
    }

    void Jump() {  
        rb.AddForce(jumpForceVector);
        jumpCount++;
    }

    void FastFall() {
        rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y * 1.03f, 0);
    }

    public IEnumerator ResetJump() 
    {
        yield return new WaitForSeconds(jumpDelay);
        jumpCount = 0;
    }


}
