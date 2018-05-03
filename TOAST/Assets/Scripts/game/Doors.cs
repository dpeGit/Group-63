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
        if((location[0] == 0  || ProceduralGeneration.mapLayout[location[0] - 1 , location[1]] == 0) && side == 0)
        {
            gameObject.SetActive(false);
        }else if((location[0] == 14 || ProceduralGeneration.mapLayout[location[0] + 1, location[1]] == 0) && side == 1)
        {
            gameObject.SetActive(false);
        }
        else if ((location[1] == 0 || ProceduralGeneration.mapLayout[location[0], location[1] - 1] == 0) && side == 2)
        {
            gameObject.SetActive(false);
        }
        else if ((location[1] == 14 || ProceduralGeneration.mapLayout[location[0], location[1] + 1] == 0) && side == 3)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            switch (side)
            {
                case 0:
                    PlayerStats.spawnPoint = 1;
                    SceneManager.LoadScene(ProceduralGeneration.mapLayout[location[0] - 1, location[1]]);
                    break;
                case 1:
                    SceneManager.LoadScene(ProceduralGeneration.mapLayout[location[0] + 1, location[1]]);
                    break;
                case 2:
                    SceneManager.LoadScene(ProceduralGeneration.mapLayout[location[0], location[1] - 1]);
                    break;
                case 3:
                    SceneManager.LoadScene(ProceduralGeneration.mapLayout[location[0], location[1] + 1]);
                    break;
            }
        }
    }
}
