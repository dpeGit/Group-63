using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour {

    public float attackCD;
    public float damage;
    public float knockback;
    public float projectileSpeed;
    public GameObject projectile;

    private bool isAttacking = false;
    private float attackTimer = 0f;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        if (!isAttacking)
        {
            attacking();
        }
        if (isAttacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
            }
        }
    }

    private void attacking()
    {
        if (Input.GetAxis("Fire1") == -1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            GameObject clone;
            clone = Instantiate(projectile, player.transform.position, new Quaternion(0,0,0,0));
            clone.GetComponent<playerProjectileContact>().projectileDamage = damage;
            clone.GetComponent<playerProjectileContact>().projectileKnockback = knockback;
            clone.GetComponent<Rigidbody2D>().velocity = Vector2.left * projectileSpeed;
        }
        else if(Input.GetAxis("Fire1") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            GameObject clone;
            clone = Instantiate(projectile, player.transform.position, new Quaternion(0, 0, 0, 0));
            clone.GetComponent<playerProjectileContact>().projectileDamage = damage;
            clone.GetComponent<playerProjectileContact>().projectileKnockback = knockback;
            clone.GetComponent<Rigidbody2D>().velocity = Vector2.right * projectileSpeed;
        }
        else if (Input.GetAxis("Fire2") == -1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            GameObject clone;
            clone = Instantiate(projectile, player.transform.position, new Quaternion(0, 0, 0, 0));
            clone.GetComponent<playerProjectileContact>().projectileDamage = damage;
            clone.GetComponent<playerProjectileContact>().projectileKnockback = knockback;
            clone.GetComponent<Rigidbody2D>().velocity = Vector2.down * projectileSpeed;
        }
        else if (Input.GetAxis("Fire2") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            GameObject clone;
            clone = Instantiate(projectile, player.transform.position, new Quaternion(0, 0, 0, 0));
            clone.GetComponent<playerProjectileContact>().projectileDamage = damage;
            clone.GetComponent<playerProjectileContact>().projectileKnockback = knockback;
            clone.GetComponent<Rigidbody2D>().velocity = Vector2.up * projectileSpeed;
        }
    }
}
