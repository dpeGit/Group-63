using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {

    public GameObject player;
    public float speed;
	
	void Update () {
        Vector2 playerPosition = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed);
	}
}
