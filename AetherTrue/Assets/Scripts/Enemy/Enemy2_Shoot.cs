using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2_Shoot : MonoBehaviour
{

[SerializeField]
GameObject projectile;
Transform target;


[SerializeField]
Transform shootPoint;

[SerializeField]
float turnSpeed = 5;
float fireRate = 0.2f;

private void Start(){

    target = GameObject.FindGameObjectWithTag("Player").transform;
     //remember to tag player as "player" in interface

}


private void Update(){
 fireRate -= Time.deltaTime;
 Vector3 direction =  transform.position - target.position;
 transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);



if (fireRate <= 0){

    fireRate = 0.5f; //hard coded here
    Shoot();
}

}



void Shoot(){
    Instantiate(projectile, shootPoint.position, shootPoint.rotation);
}

}
