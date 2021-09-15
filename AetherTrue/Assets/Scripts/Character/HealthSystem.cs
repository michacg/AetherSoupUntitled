using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;



public class HealthSystem :MonoBehaviour
{

public Image[] hearts; //make list instead and get hurt method
public int health;


 void Start()
    {
    health = hearts.Length;
    }



// public void Death(int health){

// if (health == 0){
//     //death animation
//     return;
// };

// }


public int GetHealth(){
    return health;
}


public void Damage(int d){
    health -= d;
}

   
    void Update()
      {


      if (health < 1){
          Destroy(hearts[0].gameObject); //disable instead? check if null first
      }
      else if (health < 2){
             Destroy(hearts[1].gameObject);
      }
           else if (health< 3){
             Destroy(hearts[2].gameObject);
      }
    else if (health ==0){
                return;
    }



//  if (Input.GetKeyDown(KeyCode.Space)){
//      health --;
//      Debug.Log("health is" + health);
//  }

      }
    
//decrease player health on collision with enemy
void OnCollision(Collision _collision){
    if(_collision.gameObject.tag =="enemy"){
        Debug.Log("enemy collision");
        health-=1;



        //put the if statements here?
    }
}



}

        

        // move();
    





