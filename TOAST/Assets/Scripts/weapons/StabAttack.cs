using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabAttack: MonoBehaviour {

    public float baseAttackCD, attackSpeedMult;
    public float radius;
    public float range;
    public float baseDamage, strengthMult, agilityMult;
    public float knockback;

    private bool isAttacking = false;
    private float attackTimer = 0f;
    public float damage;//public for testing
    public float attackCD;//public for testing
    private GameObject player;
    private SpriteRenderer display;

    //set variables
    private void Start()
    {
        player = GameObject.Find("player");
        updateStats();
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
            sendDamage(hitObjects);
        }
        else if (Input.GetAxis("Fire1") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x + radius, transform.position.y);

            RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(transform.position, radius, Vector2.right, range);
            sendDamage(hitObjects);
        }
        else if (Input.GetAxis("Fire2") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x, transform.position.y + radius);
            transform.Rotate(Vector3.forward, 90);

            RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(transform.position, radius, Vector2.up, range);
            sendDamage(hitObjects);
        }
        else if (Input.GetAxis("Fire2") == -1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x, transform.position.y - radius);
            transform.Rotate(Vector3.forward, 270);

            RaycastHit2D[] hitObjects = Physics2D.CircleCastAll(transform.position, radius, Vector2.down, range);
            sendDamage(hitObjects);
        }
    }

    private void sendDamage(RaycastHit2D[] hitObjects)
    {
        float[] hitPackage = new float[2] { damage, knockback };

        for (int i = 0; i < hitObjects.Length; i++)//cycles throuhg the enemeys hit and looks for tag "enemy"
        {
            if (hitObjects[i].collider.tag == "enemy")
            {
                Debug.Log("Stab hit " + hitObjects[i].collider.name);
                hitObjects[i].collider.SendMessage("damage", hitPackage);//sends damage
            }
        }
    }

    public void updateStats()
    {
        damage = baseDamage * strengthMult * player.GetComponent<PlayerStats>().strength + baseDamage * agilityMult * player.GetComponent<PlayerStats>().agility;
        attackCD = baseAttackCD * (1 / (attackSpeedMult * player.GetComponent<PlayerStats>().attackSpeed));
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
