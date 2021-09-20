using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;



public class EnemyHealthSystem :MonoBehaviour
{


public GameObject damageburst;

public int health;


 void Start()
    {
   
    }




public int GetHealth(){
    return health;
}


public void Damage(int d){
    health -= d;
}

   
    void Update()
      {
// if (health ==0){
//     Destroy(gameObject); //removes whatever 
// }
    
    }

void OnCollisionEnter(Collision _collision){
    if(_collision.gameObject.tag =="Player"){
        Debug.Log("enemy collision");
        health-=1;
  //  Destroy(gameObject);
        Instantiate(damageburst, transform.position, transform.rotation); //particle effects



        //put the if statements here?
    }
}



}


//  if (Input.GetKeyDown(KeyCode.Space)){
//      health --;
//      Debug.Log("health is" + health);
//  }

      
    
//decrease player health on collision with enemy

        

        // move();
    





