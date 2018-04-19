using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int exp, expNeeded;
    public int level;
    public float runSpeedMult;
    public float currentHealth, maxHealth, baseHealth;
    public float regenTime, baseRegenAmount, regenMult;
    public int strength, agility;
    public int attackSpeed;
    public int mana;

    private float regenTimer;
    public float regenAmount;//public for testing

	// Use this for initialization
	void Start () {
        exp = 0;
        expNeeded = 1000;
        level = 1;
        maxHealth = baseHealth;
        currentHealth = maxHealth;
        GetComponent<Movement>().speed = GetComponent<Movement>().baseSpeed * runSpeedMult * agility;
        regenAmount = baseRegenAmount * regenMult * strength;
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

    private void Update()
    {
        if(regenTimer <= 0)
        {
            hpRegen();
        }
        else
        {
            regenTimer -= Time.deltaTime;
        }
    }

    void expGain(int expGain)
    {
        exp += expGain;
        if(exp >= expNeeded)
        {
            levelUp();
        }
    }

    private void levelUp()
    {
        exp -= expNeeded;
        level++;
        if(level % 5 == 0)//special things happen every 5th level
        {
            baseHealth += 10;
            strength += 1;
            agility += 1;
            attackSpeed += 1;
        }
        //TODO put anything that need to happen on level up here, also consider everything here unbalenced
        expNeeded = (int)Math.Floor(expNeeded * Math.Pow(1.01,(double) level));
        float deltaHealth = baseHealth * (float)Math.Pow(1.01, (double)level) - maxHealth;
        maxHealth += deltaHealth;
        currentHealth += deltaHealth;
        GetComponent<Movement>().speed = GetComponent<Movement>().baseSpeed * runSpeedMult * agility;
        regenAmount = baseRegenAmount * regenMult * strength;
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
        foreach(GameObject i in weapons)
        {
            i.SendMessage("updateStats");
        }
    }

    void hpRegen()
    {
        regenTimer = regenTime;
        currentHealth += regenAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
