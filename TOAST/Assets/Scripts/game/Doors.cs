using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Doors : MonoBehaviour {


    public int side;//the direction the door is in use 0 for west, 1 for east, 2 for south, 3 for north

    [HideInInspector]
    static public int[] location;

    private void Start()
    {
        if((location[0] == 0  || ProceduralGeneration.mapLayout[location[0] - 1 , location[1]] == -1) && side == 0)
        {
            gameObject.SetActive(false);
        }else if((location[0] == 14 || ProceduralGeneration.mapLayout[location[0] + 1, location[1]] == -1) && side == 1)
        {
            gameObject.SetActive(false);
        }
        else if ((location[1] == 0 || ProceduralGeneration.mapLayout[location[0], location[1] + 1] == -1) && side == 2)
        {
            gameObject.SetActive(false);
        }
        else if ((location[1] == 14 || ProceduralGeneration.mapLayout[location[0], location[1] - 1] == -1) && side == 3)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player" && GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {

            SpawnRooms.layout[location[0], location[1]].SetActive(false);
            MiniMap.setGrey();
            foreach(GameObject projectile in GameObject.FindGameObjectsWithTag("projectile"))
            {
                Destroy(projectile);
            }

            switch (side)
            {
			case 0:
					PlayerStats.spawnPoint = 1;
					location [0] -= 1;
	                break;
                case 1:
                    PlayerStats.spawnPoint = 0;
                    location[0] += 1;
                    break;
				case 2:
					PlayerStats.spawnPoint = 3;
					location [1] += 1;
                    break;
                case 3:
                    PlayerStats.spawnPoint = 2;
                    location[1] -= 1;
                    break;
            }

            Debug.Log(location[0] + " " + location[1]);
            SpawnRooms.layout[location[0], location[1]].SetActive(true);
            MiniMap.setGold();
            collision.GetComponent<PlayerStats>().spawn();
        }
    }
}
