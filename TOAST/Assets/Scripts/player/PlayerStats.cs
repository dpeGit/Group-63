using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int exp, expNeeded;
    public int level;
    public float health;

	// Use this for initialization
	void Start () {
        exp = 0;
        expNeeded = 1000;
        level = 1;
	}
        

	void Update () {
        //leveling
        if (exp >= expNeeded)
        {
            level++;
            exp = exp % expNeeded;
            expNeeded += 1000;
        }
    }

    void playerDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player Health" + health);
        if (health <= 0)
        {
            GameObject.Find("player").SetActive(false);
        }
    }
}
