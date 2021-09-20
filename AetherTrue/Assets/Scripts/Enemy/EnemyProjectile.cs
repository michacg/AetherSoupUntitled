using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyProjectile : MonoBehaviour
{

[SerializeField]
//public int damage = 10f;



Rigidbody rb;


[SerializeField]
float speed = 500f;


private void Awake(){
    rb = GetComponent<Rigidbody>();
    Transform target = GameObject.FindGameObjectWithTag("Player").transform;
    Vector3 direction = target.position - transform.position;
    rb.AddForce(direction * speed * Time.deltaTime);
}


private void OnCollisionEnter(Collision collision){
    if(collision.transform.tag == "Player"){ //if a ball hits the player
       HealthSystem playerHealth = collision.transform.GetComponent<HealthSystem>();
       playerHealth.Damage(10); //takes 10 health away each hit
       Destroy(gameObject);
    }

    else{
    //  Destroy(gameObject);
    }
}


}
