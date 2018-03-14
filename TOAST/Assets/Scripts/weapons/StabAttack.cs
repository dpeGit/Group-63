using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabAttack: MonoBehaviour {

    private bool isAttacking = false;
    private float attackTimer = 0f;
    private float[] hitPackage;

    public float attackCD;
    public float radius;
    public float range;
    public float damage;
    public float knockback;

    private void Start()
    {
        hitPackage = new float[2];
        hitPackage[0] = damage;
        hitPackage[1] = knockback;
    }

    private void Update()
    {
        if (!isAttacking)
        {
            if (Input.GetAxis("Fire1") == -1)
            {
                isAttacking = true;
                attackTimer = attackCD;

                RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(new Vector2(transform.position.x - radius, transform.position.y), radius, Vector2.left, range);
                for (int i = 0; i < hitObjects.Length; i++)
                {
                    if (hitObjects[i].collider.tag == "Enemy")
                    {
                        Debug.Log("Stab hit " + hitObjects[i].collider.name);
                        hitObjects[i].collider.SendMessage("damage", hitPackage);
                    }
                }
            }
            else if (Input.GetAxis("Fire1") == 1)
            {
                isAttacking = true;
                attackTimer = attackCD;

                RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(new Vector2(transform.position.x + radius, transform.position.y), radius, Vector2.right, range);
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

                RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(new Vector2(transform.position.x, transform.position.y + radius), radius, Vector2.up, range);
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

                RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(new Vector2(transform.position.x, transform.position.y - radius), radius, Vector2.down, range);
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
    //uncoment this function if you need to check ranges
    
    private void OnDrawGizmosSelected()
    {
        //left hitbox
        Gizmos.DrawSphere(new Vector3(transform.position.x - radius, transform.position.y, transform.position.z), radius);
        Gizmos.DrawSphere(new Vector3(transform.position.x - radius - range, transform.position.y, transform.position.z), radius);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - range, transform.position.y, transform.position.z));

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
        
}
