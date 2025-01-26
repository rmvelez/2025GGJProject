using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerMovement instance;
    private Rigidbody rb;
    private Animator animator;
    
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpForce = 500f;

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

    float Health = 100;
    float Damage = 2
    {
        get {return jumpForce;}
        private set {jumpForce = value;}
    }

    public bool isFacingRight = true;
    public bool isGrounded;
    public bool isAirborne;
    public float currentSpeed;
    public float bubbleFloat;



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
   
    void Update() {

        //FACE LEFT OR RIGHT//
        if (isFacingRight == true) {
            transform.rotation = new Quaternion(transform.rotation.x, 120f, transform.rotation.z, transform.rotation.w);
        }
        else {
            transform.rotation = new Quaternion(transform.rotation.x, 230f, transform.rotation.z, transform.rotation.w);
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


        airVelocity = new Vector2(speed / 2, 0);

        #region AirborneMovement
/*
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
            rb.AddForce(new Vector2(0f, bubbleFloat));
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

        jumpForceVector = new Vector2 (0f, jumpForce);
        
        #region Jump
        if (Input.GetButtonDown("Jump") && jumpCount < jumpMax)
        { 
            Jump();
        }

        if (Input.GetButtonUp("Jump")) {
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y / 2);
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
        rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * 1.03f);
    }

    public IEnumerator ResetJump() 
    {
        yield return new WaitForSeconds(jumpDelay);
        jumpCount = 0;
    }


}
*/
