using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int exp;
    public int level;
    public float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
    public int strength, agility, intellect, vitality, armour, luck; //public for testing
    public int mana;

    [HideInInspector]
    public int expNeeded;
    [HideInInspector]
    public int currentHealth, maxHealth;

    [HideInInspector]
    static public int spawnPoint;

    private int levelsGained;

    // Use this for initialization
    void Awake () {
        exp = 0;
        expNeeded = 1000;
        level = 1;//TODO persistant player leveling
        maxHealth = (int)(vitality * 20 * healthMult);
        currentHealth = maxHealth;
        mana = (int) (intellect * 30 * manaMult);
        GetComponent<Movement>().speed = GetComponent<Movement>().baseSpeed * runSpeedMult;

        switch (spawnPoint)
        {
            case 0://west
                transform.position = new Vector2(-10, 0);
                break;
            case 1://east
                transform.position = new Vector2(10, 0);
                break;
            case 2://south
                transform.position = new Vector2(0, -5);
                break;
            case 3://north
                transform.position = new Vector2(0, 5);
                break;
            case 4://middle
                transform.position = new Vector2(0, 0);
                break;
            default:
                break;
        }
    }

    void playerDamage(float damage)
    {
        currentHealth  = currentHealth - (int)(damage * Math.Min((Math.Pow(damage/armour,0.5) * 0.5),1));
        Debug.Log("Player Health" + currentHealth);
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void expGain(int expGain)
    {
        exp += expGain;
        if(exp >= expNeeded)
        {
            levelsGained++;
            exp -= expNeeded;
            expNeeded = (int)Math.Floor(expNeeded * Math.Pow(1.01, (double)level)); //TODO balence this formular just temp for now
        }
    }
}
