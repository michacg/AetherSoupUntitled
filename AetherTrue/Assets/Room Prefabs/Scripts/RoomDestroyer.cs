using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SpawnPoint")
        {
             Destroy(other.transform.gameObject);
        }
        
    }
}
