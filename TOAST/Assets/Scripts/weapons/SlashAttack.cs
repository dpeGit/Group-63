using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack: MonoBehaviour {

    public float attackCD;
    public float range;
    public float damage;
    public float knockback;

    private bool isAttacking = false;
    private float attackTimer = 0f;
    private float[] hitPackage;
    private GameObject player;
    private SpriteRenderer display;

    //sets varaibles disables the display for the weapon by default, sets the scale of the weapon to match range
    private void Start()
    {
        hitPackage = new float[2];
        hitPackage[0] = damage;
        hitPackage[1] = knockback;
        player = GameObject.Find("player");
        display = GetComponent<SpriteRenderer>();
        display.enabled = false;
        transform.localScale = new Vector3(2 * range, 2 * range, 0);//TODO stop gap measure for demo should not be needed with proper sprites
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
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                display.enabled = true;
            }
            else
            {
                isAttacking = false;
                display.enabled = false;
                transform.position = player.transform.position;
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

            transform.position = new Vector2(transform.position.x - range, transform.position.y); //changes the postion of the object to the attack area
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range); //draws a hitbox
            for (int i = 0; i < hitObjects.Length; i++) //cycles throuhg the enemeys hit and looks for tag "enemy"
            {
                if (hitObjects[i].tag == "Enemy")
                {
                    Debug.Log("Slash hit " + hitObjects[i].name);
                    hitObjects[i].SendMessage("damage", hitPackage); //sends damage
                }
            }
        }
        else if (Input.GetAxis("Fire1") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x + range, transform.position.y);
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range);
            for (int i = 0; i < hitObjects.Length; i++)
            {
                if (hitObjects[i].tag == "Enemy")
                {
                    Debug.Log("Slash hit " + hitObjects[i].name);
                    hitObjects[i].SendMessage("damage", hitPackage);
                }
            }
        }
        else if (Input.GetAxis("Fire2") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x, transform.position.y + range);
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range);
            for (int i = 0; i < hitObjects.Length; i++)
            {
                if (hitObjects[i].tag == "Enemy")
                {
                    Debug.Log("Slash hit " + hitObjects[i].name);
                    hitObjects[i].SendMessage("damage", hitPackage);
                }
            }
        }
        else if (Input.GetAxis("Fire2") == -1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x, transform.position.y - range);
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range);
            for (int i = 0; i < hitObjects.Length; i++)
            {
                if (hitObjects[i].tag == "Enemy")
                {
                    Debug.Log("Slash hit " + hitObjects[i].name);
                    hitObjects[i].SendMessage("damage", hitPackage);
                }
            }
        }
    }
    //uncoment this function if you need to check ranges
    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(new Vector3(transform.position.x - range, transform.position.y, transform.position.z), range);
        Gizmos.DrawSphere(new Vector3(transform.position.x + range, transform.position.y, transform.position.z), range);
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - range, transform.position.z), range);
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y + range, transform.position.z), range);
    }
    */
}
