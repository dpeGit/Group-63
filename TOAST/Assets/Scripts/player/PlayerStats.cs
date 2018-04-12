using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int exp, expNeeded;
    public int level;
    public float currentHealth, maxHealth;
    public float regenTime;

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
        currentHealth -= damage;
        Debug.Log("Player Health" + currentHealth);
        if (currentHealth <= 0)
        {
            GameObject.Find("player").SetActive(false);
        }
    }

    void hpRegen(float amount)
    {
        //increases hp by amount
    }
}
