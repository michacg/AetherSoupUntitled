using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    private float walkSpeed = 2.3f;
    private float sprintSpeed = 5f;
    private float moveSpeed;
    private Vector3 resetVector;

    private Camera playerCamera;

    private CharacterController playerMovement;
    private Animator animator;
    private int playerState;

    private Rigidbody _rb;
    void Start()
    {

        _rb = GetComponent<Rigidbody>();

        playerCamera = Camera.main;

        playerMovement = GetComponent<CharacterController>();

        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        //control inputs
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        //bool sprintInput = (Input.GetKeyDown(KeyCode.LeftShift));

        //camera local coordinate reference
        var forward = playerCamera.transform.forward;
        var right = playerCamera.transform.right;

        //normalizing camera coordinates
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //direction that movement will reference (controller default)
        var cameraControlDirection = forward * vInput + right * hInput;

        moveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;




        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            playerState = 1;
        }

        else if (!Input.anyKey)
        {
            playerState = 0;
        }

        if (playerState == 1)
        {

            if (moveSpeed == walkSpeed)
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
            }

            if (moveSpeed == sprintSpeed)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", true);
            }

        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        resetVector = Vector3.zero;

        if (playerMovement.isGrounded == false)
        {
            resetVector += Physics.gravity;
        }

        playerMovement.Move(cameraControlDirection * moveSpeed * Time.deltaTime);
        playerMovement.Move(resetVector * Time.deltaTime);

        //transforms player toward movement direction
        Vector3 lookDirection = cameraControlDirection + gameObject.transform.position;
        gameObject.transform.LookAt(lookDirection);

        var actionIsPlaying = false;

        if (actionIsPlaying == true)
        {
            moveSpeed = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("isShoving");
            actionIsPlaying = true;
        }
        else
        {
            actionIsPlaying = false;
        }

    }
}