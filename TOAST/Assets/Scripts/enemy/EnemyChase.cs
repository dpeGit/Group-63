using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {

    public GameObject player;
    public float speed;
    public float damageOnHit;
    public float damageCD;

    private Rigidbody2D enemy;
    private float knockbackCD;
    private bool isKnockBack;
    private float damageTimer = 0f;

    //assigned varaibles
    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
    }

    private void Update()
    {
        if (damageTimer <= 0)
        {
            if (enemy.IsTouching(player.GetComponent<Collider2D>()))
            {
                player.SendMessage("playerDamage", damageOnHit);
                damageTimer = damageCD;
            }
        }
        else
        {
            damageTimer -= Time.deltaTime;
        }
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
