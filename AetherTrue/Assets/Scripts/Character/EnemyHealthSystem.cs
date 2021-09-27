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
    if(_collision.gameObject.tag =="Player"){ //optimize
        Debug.Log("enemy collision");
        health-=1;
        Instantiate(damageburst, transform.position, transform.rotation); //particle effects

if(health<=0){
    Death();
}
        //put the if statements here?
    }
}


private void Death(){
    Destroy(gameObject);
}


}






