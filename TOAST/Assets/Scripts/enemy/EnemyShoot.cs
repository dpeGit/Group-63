using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject projectile;
    public float projectileSpeed;
    public float projectileDamage;
    public float speed;
    public float contactDamage;
    public float contactCD;
    public float fireRange;
    public float fireCD;
    public float health;
    public int expValue;

    private Rigidbody2D enemy;
    private GameObject player;
    private float stunCD;
    private float contactTimer = 0f;
    private float fireTimer = 0f;

    //assigned varaibles
    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
    }


    //moves the enemy towards the player unless it is knocked back in which case calls the knockback function
    private void FixedUpdate()
    {
        cooldowns();
        contact();

        if (stunCD <= 0)
        {
            if (Vector2.Distance(player.transform.position, enemy.transform.position) >= fireRange)
            {
                enemy.velocity = (player.transform.position - enemy.transform.position).normalized * speed;
            }
            else
            {
                fireProjectile();
            }
        }
        else
        {
            stunCD -= Time.deltaTime;
        }
    }

    private void fireProjectile()
    {
        if (fireTimer <= 0)
        {
            GameObject clone;
            clone = Instantiate(projectile, enemy.transform.position, new Quaternion(0, 0, 0, 0));
            clone.GetComponent<projectileContact>().projectileDamage = projectileDamage;
            clone.GetComponent<Rigidbody2D>().velocity = (player.transform.position - enemy.transform.position).normalized * projectileSpeed;
            fireTimer = fireCD;
        }
    }

    private void cooldowns()
    {
        fireTimer -= Time.deltaTime;
        contactTimer -= Time.deltaTime;
    }

    private void contact()
    {
        if (contactTimer <= 0)
        {
            if (enemy.IsTouching(player.GetComponent<Collider2D>()))
            {
                player.SendMessage("playerDamage", contactDamage);
                contactTimer = contactCD;
            }
        }
    }

    //takes a varaiable knockback (based off the weapon) then applies a force in the opposite direction from the player
    //also stunned for a duration based off the weapon
    public void knockback(float knockback)
    {
        enemy.velocity = Vector2.zero;
        enemy.AddForce(-(player.transform.position - enemy.transform.position).normalized * knockback);
        stunCD = knockback / 500; //TODO temporrary function
    }

    public void stun(float stunDuration)
    {
        stunCD = stunDuration;
    }

    public void damage(float[] results)
    {
        health -= results[0];
        knockback(results[1]);  
        Debug.Log(health);
        if (health <= 0)
        {
            gameObject.SetActive(false);
            player.SendMessage("expGain", expValue);
        }
    }
}
