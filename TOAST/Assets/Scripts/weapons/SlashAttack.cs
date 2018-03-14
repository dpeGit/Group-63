using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack: MonoBehaviour {

    private bool isAttacking = false;
    private float attackTimer = 0f;
    private float[] hitPackage;
    private GameObject player;

    public float attackCD;
    public float range;
    public float damage;
    public float knockback;

    private void Start()
    {
        hitPackage = new float[2];
        hitPackage[0] = damage;
        hitPackage[1] = knockback;
        player = GameObject.Find("player");
    }

    private void Update()
    {
        if (!isAttacking)
        {
            if (Input.GetAxis("Fire1") == -1)
            {
                isAttacking = true;
                attackTimer = attackCD;
                transform.position = new Vector2(transform.position.x - range, transform.position.y);
                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range);
                for(int i = 0; i < hitObjects.Length; i++)
                {
                    if (hitObjects[i].tag == "Enemy")
                    {
                        Debug.Log("Slash hit " + hitObjects[i].name);
                        hitObjects[i].SendMessage("damage", hitPackage);
                    }
                }
                transform.position = player.transform.position;
            }
            else if(Input.GetAxis("Fire1") == 1)
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
                transform.position = player.transform.position;
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
                transform.position = player.transform.position;
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
            transform.position = player.transform.position;
        }
        if (isAttacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
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
