using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour {


    public static GameObject[,] layout;

	void Awake (){

        layout = new GameObject[15, 15];
        for(int i = 0; i < 15; i++)
        {
            for(int k = 0; k < 15; k++)
            {
                if(ProceduralGeneration.mapLayout[i,k] != -1)
                {
                    layout[i, k] = Instantiate(ProceduralGeneration.rooms[ProceduralGeneration.mapLayout[i, k]]);
                    layout[i, k].SetActive(false);
                }
            }
        }

        layout[7, 7].SetActive(true);
    }


}
