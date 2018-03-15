﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabAttack: MonoBehaviour {

    public float attackCD;
    public float radius;
    public float range;
    public float damage;
    public float knockback;

    private bool isAttacking = false;
    private float attackTimer = 0f;
    private float[] hitPackage;
    private GameObject player;
    private SpriteRenderer display;

    //set variables
    private void Start()
    {
        hitPackage = new float[2];
        hitPackage[0] = damage;
        hitPackage[1] = knockback;
        player = GameObject.Find("player");
        display = GetComponent<SpriteRenderer>();
        display.enabled = false;
        transform.localScale = new Vector3(2 * (radius + range), 4, 0);//TODO stop gap measure for demo should not be needed with proper sprites
    }

    //checks if the player is currently attacking if so waits for the CD and enables the display if not attacking looks for input
    private void Update()
    {
        if (!isAttacking)
        {
            attacking();  
        }
        if (isAttacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                display.enabled = true;
            }
            else
            {
                isAttacking = false;
                display.enabled = false;
                transform.SetPositionAndRotation(player.transform.position, new Quaternion(0, 0, 0, 0));
            }
        }
    }

    //checks input for attack direction if enemy is hit calls damage() method sets isAttacking to true and attackCD to attackTimer
    private void attacking()
    {
        if (Input.GetAxis("Fire1") == -1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x - radius, transform.position.y);//changes the postion of the object to the attack area
            transform.Rotate(Vector3.forward, 180);//rotates to attack postion

            RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(transform.position, radius, Vector2.left, range);//draws a hitbox
            for (int i = 0; i < hitObjects.Length; i++)//cycles throuhg the enemeys hit and looks for tag "enemy"
            {
                if (hitObjects[i].collider.tag == "Enemy")
                {
                    Debug.Log("Stab hit " + hitObjects[i].collider.name);
                    hitObjects[i].collider.SendMessage("damage", hitPackage);//sends damage
                }
            }
        }
        else if (Input.GetAxis("Fire1") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x + radius, transform.position.y);

            RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(transform.position, radius, Vector2.right, range);
            for (int i = 0; i < hitObjects.Length; i++)
            {
                if (hitObjects[i].collider.tag == "Enemy")
                {
                    Debug.Log("Stab hit " + hitObjects[i].collider.name);
                    hitObjects[i].collider.SendMessage("damage", hitPackage);

                }
            }
        }
        else if (Input.GetAxis("Fire2") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x, transform.position.y + radius);
            transform.Rotate(Vector3.forward, 90);

            RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(transform.position, radius, Vector2.up, range);
            for (int i = 0; i < hitObjects.Length; i++)
            {
                if (hitObjects[i].collider.tag == "Enemy")
                {
                    Debug.Log("Stab hit " + hitObjects[i].collider.name);
                    hitObjects[i].collider.SendMessage("damage", hitPackage);

                }
            }
        }
        else if (Input.GetAxis("Fire2") == -1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x, transform.position.y - radius);
            transform.Rotate(Vector3.forward, 270);

            RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(transform.position, radius, Vector2.down, range);
            for (int i = 0; i < hitObjects.Length; i++)
            {
                if (hitObjects[i].collider.tag == "Enemy")
                {
                    Debug.Log("Stab hit " + hitObjects[i].collider.name);
                    hitObjects[i].collider.SendMessage("damage", hitPackage);

                }
            }
        }
    }
    //uncoment this function if you need to check ranges
    /*
    private void OnDrawGizmosSelected()
    {
        //left hitbox
        Gizmos.DrawSphere(new Vector3(transform.position.x - radius, transform.position.y, transform.position.z), radius);
        Gizmos.DrawSphere(new Vector3(transform.position.x-range - radius, transform.position.y, transform.position.z), radius);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x-radius - range, transform.position.y, transform.position.z));

        //right hitbox
        Gizmos.DrawSphere(new Vector3(transform.position.x + radius, transform.position.y, transform.position.z), radius);
        Gizmos.DrawSphere(new Vector3(transform.position.x + radius + range, transform.position.y, transform.position.z), radius);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + range, transform.position.y, transform.position.z));

        //up hitbox
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y + radius, transform.position.z), radius);
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y + radius + range, transform.position.z), radius);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + range, transform.position.z));

        //down hitbox
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - radius, transform.position.z), radius);
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - radius - range, transform.position.z), radius);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - range, transform.position.z));
    }
    */   
}
