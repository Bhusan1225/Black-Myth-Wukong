using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    
    private float moveX;
    private float moveZ;

    [SerializeField]
    private CameraController playerCamera;
    
    [SerializeField]
    private float rotSpeed = 600f;
    Quaternion requiredRotation;
   
    
   
    Vector3 velocity;
   

    [SerializeField]
    private float movementAmout;
    Vector3 movementDirection;

    //player Animation
    Animator animator;

    [Header ("Player Collision & Gravity")]
    public CharacterController characterController;
    //[SerializeField] private Transform groundCheck;
    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] bool isGrounded;


    [SerializeField]
    float fallingSpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            fallingSpeed = -0.5f;
        }
        else
        {
            fallingSpeed += Physics.gravity.y *Time.deltaTime;
        }

        var velocity = movementDirection * speed;
        velocity.y = fallingSpeed;

        PlayerMovement();
        PlayerMovementAnimation();
        GroundCheck();

        
    }

    public void PlayerMovement()
    {
     

        // will give direction
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        //check if the target is moving
        movementAmout = Mathf.Clamp01(Mathf.Abs(moveX) + Mathf.Abs(moveZ));

        //combine this above 2 direction
        var movementInput = (new Vector3(moveX, 0, moveZ)).normalized;

        movementDirection = playerCamera.flatRoation * movementInput;
        characterController.Move(movementDirection * speed * Time.deltaTime);

        if (movementAmout > 0)
        {
            requiredRotation = Quaternion.LookRotation(movementDirection);
        }

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, requiredRotation, rotSpeed * Time.deltaTime); // for the smooth roation
    }

    void PlayerMovementAnimation()
    {
        animator.SetFloat("Move", movementAmout);
    }
   

    void GroundCheck()
    {
        //ground check
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundDistance, groundLayer);

    }

    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.yellow;

       Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundDistance);

    }

}

