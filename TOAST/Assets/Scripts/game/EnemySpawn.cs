using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime;

    private bool autoSpawn = false;
    private float spawnCD;

    //when p is pressed starts spawning enemies
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            if (autoSpawn)
            {
                autoSpawn = false;
            }
            else
            {
                autoSpawn = true;
                spawnCD = spawnTime;
            }
        }

		if(autoSpawn && spawnCD <= 0)
        {
            Instantiate(enemy, transform.position, new Quaternion(0, 0, 0, 0));
            spawnCD = spawnTime;
        }
        else
        {
            spawnCD -= Time.deltaTime;
        }
	}
}
