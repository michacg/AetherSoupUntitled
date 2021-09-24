using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;



public class HealthSystem :MonoBehaviour
{

public Image[] hearts; //make list instead and get hurt method
public GameObject damageburst;
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




public void AddLife(){
    health+=1;
}

   
    void Update()
      {




int count = health;
for (int i = 0; i < hearts.Length; i++){ //need number of hearts equal to health

    if(i+1>health){
        //   Debug.Log(i);
         hearts[i].gameObject.SetActive(false);
    }
    else{
        hearts[i].gameObject.SetActive(true);
    }
}



if (health <= 0){
    health = 0;
}
      }



// IEnumerator Flashing() {
//     for (int i=0;i<2;i++) { //flashes 2 times
//         gameObject.GetComponent<MeshRenderer>().material = Material2;
//         yield return new WaitForSeconds(0.5f);
//     gameObject.GetComponent<MeshRenderer>().material = Material1;
//     yield return new WaitForSeconds(0.5f);
// }
// }
    
//decrease player health on collision with enemy
void OnTriggerEnter(Collider _collision){

    if(_collision.gameObject.tag =="Enemy"){
        health-=1;
      //  StartCoroutine(Flash());
        Instantiate(damageburst, transform.position, transform.rotation); //particle effects


//this doesnt work, even tho both objects have a collider
     if(_collision.gameObject.tag =="Heal"){
         AddLife();
         Debug.Log("hiiii");
         Destroy(_collision.gameObject);
         }

        //heal upon collision w potion
    }
}




}



        

  
    





