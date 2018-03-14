using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {

    public GameObject player;
    public float speed;

    private Rigidbody2D enemy;

    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
         enemy.velocity = (player.transform.position - enemy.transform.position).normalized * speed;
	}
}
