using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemy;
    public float spawnTime;

    private bool autoSpawn = false;
    private float lastSpawn = 0;

	void Update () {
        if (Input.GetKeyDown("p"))
        {
            if (autoSpawn)
                autoSpawn = false;
            else
                autoSpawn = true;
        }

		if(autoSpawn && Time.time - lastSpawn > spawnTime)
        {
            Instantiate(enemy, transform.position, new Quaternion(0, 0, 0, 0));
            lastSpawn = Time.time;
        }
	}
}
