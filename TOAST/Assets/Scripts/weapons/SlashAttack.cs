using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack: MonoBehaviour {

    public float baseAttackCD;
    public float range;
    public float baseDamage, strengthMult, agilityMult, intMult;
    public float knockback;

    private bool isAttacking = false;
    private float attackTimer = 0f;
    public float damage;//public for testing
    public float attackCD;//public for testing
    private GameObject player;
    private SpriteRenderer display;

    //sets varaibles disables the display for the weapon by default, sets the scale of the weapon to match range
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        updateStats();
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
            sendDamage(hitObjects);
        }
        else if (Input.GetAxis("Fire1") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x + range, transform.position.y);
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range);
            sendDamage(hitObjects);
        }
        else if (Input.GetAxis("Fire2") == 1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x, transform.position.y + range);
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range);
            sendDamage(hitObjects);
        }
        else if (Input.GetAxis("Fire2") == -1)
        {
            isAttacking = true;
            attackTimer = attackCD;

            transform.position = new Vector2(transform.position.x, transform.position.y - range);
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range);
            sendDamage(hitObjects);
        }
    }

    private void sendDamage(Collider2D[] hitObjects)
    {
        float[] hitPackage = new float[2] { damage, knockback };
        for (int i = 0; i < hitObjects.Length; i++) //cycles throuhg the enemeys hit and looks for tag "enemy"
        {
            if (hitObjects[i].tag == "enemy")
            {
                Debug.Log("Slash hit " + hitObjects[i].name);
                hitObjects[i].SendMessage("damage", hitPackage); //sends damage
            }
        }
    }

    public void updateStats()
    {
        damage = (baseDamage * strengthMult * player.GetComponent<PlayerStats>().strength) + (baseDamage * intMult * player.GetComponent<PlayerStats>().intellect) + (baseDamage * agilityMult * player.GetComponent<PlayerStats>().agility);
        attackCD = baseAttackCD;
        knockback *= player.GetComponent<PlayerStats>().knockbackMult;
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
