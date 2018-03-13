using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool isAttacking = false;
    private float attackTimer = 0f;

    public float attackCD;
    public float range;

    private void Update()
    {
        if (!isAttacking)
        {
            if (Input.GetAxis("Fire1") == -1)
            {
                isAttacking = true;
                attackTimer = attackCD;

                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(new Vector2(transform.position.x - range, transform.position.y), range);
                for(int i = 1; i < hitObjects.Length; i++)
                {
                    Debug.Log("Hit " + hitObjects[i].name);
                }
            }
            else if(Input.GetAxis("Fire1") == 1)
            {
                isAttacking = true;
                attackTimer = attackCD;

                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(new Vector2(transform.position.x + range, transform.position.y), range);
                for (int i = 1; i < hitObjects.Length; i++)
                {
                    Debug.Log("Hit " + hitObjects[i].name);
                }
            }
            else if (Input.GetAxis("Fire2") == 1)
            {
                isAttacking = true;
                attackTimer = attackCD;

                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + range), range);
                for (int i = 1; i < hitObjects.Length; i++)
                {
                    Debug.Log("Hit " + hitObjects[i].name);
                }
            }
            else if (Input.GetAxis("Fire2") == -1)
            {
                isAttacking = true;
                attackTimer = attackCD;

                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - range), range);
                for (int i = 1; i < hitObjects.Length; i++)
                {
                    Debug.Log("Hit " + hitObjects[i].name);
                }
            }
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
    }*/
}
