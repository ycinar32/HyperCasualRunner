using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovementTP : MonoBehaviour
{
    public CharacterController charController;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    public GameObject cam;
    public Animator animatorController;
    public Transform startingPoint;
    public Transform groundChecker;
    public GameObject CameraController;
    public GameObject wall;
    public bool gameisStarted = false;
    public float initialTime;

    public float speed;
    public float initSpeed;
    public float jumpSpeed;
    public float rotatingSpeed;
    public float gravity;

    public float diffuciltyConstant = 1f;


    public bool jumpCommandProcess = false;
    public float GroundDistance = 0.05f;
    public LayerMask Ground;

    public bool feltDown = false;
    public bool finished = false;
    public bool returnStartingPoint = false;
    public bool _isGrounded = true;
    private bool onRotatingPlatform = false;
    public int finishedOpponentCounter = 0;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;
    Vector3 direction;
    
    Vector3 moveDirUp;
    private float directionY;
    
   void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        initSpeed = speed;
    }

    void FixedUpdate()
    {

        if (transform.position.y < 0.3f)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;
      
        if (direction.magnitude >= 0.1f && !feltDown && !finished)
        {
            if (!gameisStarted)
            {
                initialTime = Time.time;
            }
            gameisStarted = true;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + (cam.transform.eulerAngles.y);
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

           
            float velocity_y = rb.velocity.y;
            rb.velocity = moveDir * speed;

            rb.velocity += new Vector3(0f, velocity_y, 0f);

            //transform.Translate(direction.normalized * speed * Time.deltaTime);
            animatorController.SetBool("isMoving", true);
        }
        else
        {
            animatorController.SetBool("isMoving", false);
        }

        if (finished)
        {
            CameraController.GetComponent<CameraSwitchController>().wallCam = true;
        }
    }
    private void Update()
    {
        if (feltDown)
        {
            StartCoroutine(ReturnHome());
        }
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Jump" + _isGrounded);
            if (_isGrounded)
            {
                rb.velocity = Vector3.up * jumpSpeed;
                //rb.AddForce(Vector3.up * jumpSpeed);
                animatorController.SetTrigger("jumping");
                _isGrounded = false;
            }
        }
        rb.AddForce(Vector3.down * gravity);

        if(transform.position.y< -5f)
        {
            speed = 0;
            feltDown = true;
            animatorController.SetTrigger("collidedWithHardObstacle");
        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if ((collision.collider.tag == "HardObstacle"))
        {
            speed = 0;
            feltDown = true;
            animatorController.SetTrigger("collidedWithHardObstacle");
        }
        if ((collision.collider.tag == "RotatingPlatform"))
        {
            transform.parent = collision.collider.transform;
            onRotatingPlatform = true;
        }
        if ((collision.collider.tag == "FinishLine"))
        {
            finished = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if ((collision.collider.tag == "RotatingPlatform"))
        {
            transform.parent = null;
           onRotatingPlatform = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((collision.collider.tag == "RotatingPlatform"))
        {
            onRotatingPlatform = true;
        }
    }

    private IEnumerator ReturnHome()
    {
        gameisStarted = false;
        yield return new WaitForSeconds(animatorController.GetCurrentAnimatorStateInfo(0).length + animatorController.GetCurrentAnimatorStateInfo(0).normalizedTime);
        rb.position = new Vector3(1f, 0f, -107.1f);
        //rb.MovePosition(new Vector3(1f, 0f, -107.1f));
        speed = initSpeed;
        feltDown = false;
    }

}
