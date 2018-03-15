using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {

    public GameObject player;
    public float speed;

    private Rigidbody2D enemy;
    private float knockbackCD;
    private bool isKnockBack;

    //assigned varaibles
    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
    }

    //moves the enemy towards the player unless it is knocked back in which case calls the knockback function
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
     //takes a varaiable knockback (based off the weapon) then applies a force in the opposite direction from the player
     //also stunned for a duration based off the weapon
    void knockback(float knockback)
    {
        isKnockBack = true;
        enemy.velocity = Vector2.zero;
        enemy.AddForce(-(player.transform.position - enemy.transform.position).normalized * knockback);
        knockbackCD = knockback/500; //TODO temporrary function
    }
}
