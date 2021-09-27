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

     if (Input.GetKeyDown(KeyCode.Space)){
        Attack();
    }

//boon 2
void OnTriggerEnter(Collider _collision){
 if(_collision.gameObject.tag =="AttackSpeed"){
         speed = 70f;
         Debug.Log("attack speed");
         Destroy(_collision.gameObject);
         }
}

    

//     void OnCollisionEnter(Collision _collision){
//   if(_collision.gameObject.tag =="AttackSpeed"){
//          speed = 70f;
//          Debug.Log("attack speed");
//          Destroy(_collision.gameObject);
//          }
// }



void Attack(){
//  animator.SetTrigger("Attack");
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

// need to add gravity

            if (moveDir != Vector3.zero)
        {
            transform.forward = moveDir; //jinny added
        }


//move is supposed to add gravity automatically
        controller.SimpleMove(moveDir);

    }




}
}