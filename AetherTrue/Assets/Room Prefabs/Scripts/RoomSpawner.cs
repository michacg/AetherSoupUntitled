using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTemplates templates;

    private int randomRoomSpawn;
    private bool spawned = false;
    public float waitTime = 0.1f;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", waitTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
   

            spawned = true;

        }
    }


    void Spawn()
    {
      if (spawned == false)
      {
            //1 is top
          if(openingDirection == 1)
          {
                randomRoomSpawn = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[randomRoomSpawn], transform.position, templates.bottomRooms[randomRoomSpawn].transform.rotation);
          }
          //2 is bottom
          else if (openingDirection == 2)
          {
                randomRoomSpawn = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[randomRoomSpawn], transform.position, templates.topRooms[randomRoomSpawn].transform.rotation);
          }
          //3 is left
          else if (openingDirection == 3)
          {
                randomRoomSpawn = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[randomRoomSpawn], transform.position, templates.rightRooms[randomRoomSpawn].transform.rotation);
          }
          //4 is right
          else if (openingDirection == 4)
          {
                randomRoomSpawn = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[randomRoomSpawn], transform.position, templates.leftRooms[randomRoomSpawn].transform.rotation);
          }

          spawned = true;
      }
    }

}
