using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject player;
    public float speed;

    private Vector2 playerPos;

	void FixedUpdate ()
    {
        playerPos = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed);
    }
}
