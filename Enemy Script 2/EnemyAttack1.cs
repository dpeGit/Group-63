using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack1 : MonoBehaviour {

    public GameObject target;
    public float attackTime;
    public float coolDown;

    void Start()
    {
        attackTime = 0;
        coolDown = 2.0f;
    }


    void Update()
    {
        if (attackTime > 0)
            attackTime -= Time.deltaTime;

        if (attackTime < 0)
            attackTime = 0;


        if (attackTime == 0)
        {
            Attack();
            attackTime = coolDown;
        }

    }

    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);

        if (distance < 3f)
        {
            if (direction > 0)
            {
                PlayerHealth1 eh = (PlayerHealth1)target.GetComponent("PlayerHealth1");
                eh.AddjustCurrentHealth(-10);
            }
        }
    }
}