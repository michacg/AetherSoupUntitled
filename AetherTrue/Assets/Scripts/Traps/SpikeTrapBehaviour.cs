using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Nea")
        {
            Debug.Log("Nea got pricked. Ouch!");
        }

       
            
    }
    void OnTriggerExit (Collider other)
    {
        if(other.name == "Nea")
        {
            Debug.Log("Never doing that again...");
        }
    }
}
