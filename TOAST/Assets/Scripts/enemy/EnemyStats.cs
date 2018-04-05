using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float health;
    public float speed;
    public float mass;
    public float damageOnHit;
    public float damageCD;
    public int expValue;
    public GameObject player;

    private Rigidbody2D rgbd;
    private EnemyChase script;

    PlayerStats playerStats;

	// Sets variables
	void Start () {
        player = GameObject.Find("player");
        playerStats = player.GetComponent<PlayerStats>();
        rgbd = GetComponent<Rigidbody2D>();
        script = GetComponent<EnemyChase>();
        rgbd.mass = mass;
        script.speed = speed;
        script.damageOnHit = damageOnHit;
        script.damageCD = damageCD;
	}

    //takes damage when hit by player
    //when health is 0 gameobject is disabled
    //calls knockback
    void damage(float[] results)
    {
        health -= results[0];
        script.SendMessage("knockback", results[1]);
        Debug.Log(health);
        if (health <= 0)
        {
            gameObject.SetActive(false);
            playerStats.exp += expValue;
        }
    }
    private void Update()
    {
    }
}
