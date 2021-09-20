using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Animator anim;
    private Vector3 moveDir = Vector3.zero;

    // [SerializeField] public UnityEvent onInteraction;

    [Header("Player Movement Controls")]
    [SerializeField] public float speed = 4f;
    [SerializeField] public float rotSpeed = 80f;
    [SerializeField] float rot = 0f;
    [SerializeField] public float radarDistance = 1.5f;

    [Header("Player Keybinds")]
    [SerializeField] public KeyCode interactionKey = KeyCode.Space;

    [Header("Other")]
    [SerializeField] private GameObject m_camera;
    private bool isSitting;

    void Start()
    {
        isSitting = false;
        controller = GetComponent<CharacterController>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        move();
    }

    void move()
    {
        //transform.LookAt(transform.position + m_camera.transform.rotation * Vector3.forward,
        //    m_camera.transform.rotation * Vector3.up);

       // if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        //{
            moveDir = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
            moveDir *= speed;
           // moveDir = transform.TransformDirection(moveDir);




            if (moveDir != Vector3.zero)
        {
            transform.forward = moveDir; //jinny added
        }
      
        
            

        // }
        // else
        // {
        //     moveDir = new Vector3(0, 0, 0);
        // }

        //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, rot, 0);

        controller.Move(moveDir * Time.deltaTime);
       // controller.transform.Rotate(0, Input.GetAxis("Horizontal"), 0); //jinny added
    }




}