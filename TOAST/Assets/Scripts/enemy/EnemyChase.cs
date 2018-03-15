using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {

    public GameObject player;
    public float speed;

    private Rigidbody2D enemy;
    private float knockbackCD;
    private bool isKnockBack;
    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
    }

    void FixedUpdate () {
        if (!isKnockBack)
        {
            enemy.velocity = (player.transform.position - enemy.transform.position).normalized * speed;
        }
        else
        {
            knockbackCD -= Time.deltaTime;
            if(knockbackCD <= 0)
            {
                isKnockBack = false;
            }
        }
	}

    void knockback(float knockback)
    {
        isKnockBack = true;
        enemy.velocity = Vector2.zero;
        enemy.AddForce(-(player.transform.position - enemy.transform.position).normalized * knockback);
        knockbackCD = knockback/500;
    }
}
