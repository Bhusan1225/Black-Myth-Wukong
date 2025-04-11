using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float moveX;
    [SerializeField]
    private float moveZ;

    [SerializeField]
    private CameraController playerCamera;
    [SerializeField]
    private float rotSpeed = 600f;
    Quaternion requiredRotation;

    //grounded
    bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance;
    [SerializeField]
    private LayerMask groundMask;
    Vector3 velocity;
    //float gravity = -9.8f ;
    [SerializeField]
    private float movementAmout;
    Vector3 movementDirection;

     
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        PlayerMovement();


    }

    public void PlayerMovement()
    {
        //ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //resetting the default velocity
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -5f;
        }


        // will give direction
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        //check if the target is moving
        movementAmout = Mathf.Clamp01(Mathf.Abs(moveX) + Mathf.Abs(moveZ));

        //combine this above 2 direction
        var movementInput = (new Vector3(moveX, 0, moveZ)).normalized;

        movementDirection = playerCamera.flatRoation * movementInput;

        if (movementAmout > 0)
        {
            this.transform.position += movementDirection * speed * Time.deltaTime;
            requiredRotation = Quaternion.LookRotation(movementDirection);
        }

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, requiredRotation, rotSpeed * Time.deltaTime); // for the smooth roation
    }
   

}

