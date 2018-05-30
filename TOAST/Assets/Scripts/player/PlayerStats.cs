using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public string playerClass;
    public int exp;
    public int level;
    public float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
    public int strength, agility, intellect, vitality, armour, luck; //public for testing
    public int currentMana, maxMana;

    [HideInInspector]
    public int expNeeded;

    //[HideInInspector]
    public int currentHealth, maxHealth;

    [HideInInspector]
    static public int spawnPoint;

	//[HideInInspector]
    public int levelsGained;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(this);

        exp = (int) GameData.data[playerClass]["exp"];
        level = (int)GameData.data[playerClass]["level"];
        levelsGained = (int)GameData.data[playerClass]["levelsGained"];
        expNeeded = (int)GameData.data[playerClass]["expNeeded"];
        runSpeedMult = Convert.ToSingle(GameData.data[playerClass]["runSpeedMult"]);
        healthMult = Convert.ToSingle(GameData.data[playerClass]["healthMult"]);
        manaMult = Convert.ToSingle(GameData.data[playerClass]["manaMult"]);
        armourMult = Convert.ToSingle(GameData.data[playerClass]["armourMult"]);
        knockbackMult = Convert.ToSingle(GameData.data[playerClass]["knockbackMult"]);
        strength = (int) GameData.data[playerClass]["strength"];
        agility = (int) GameData.data[playerClass]["agility"];
        intellect = (int) GameData.data[playerClass]["intellect"];
        vitality = (int) GameData.data[playerClass]["vitality"];
        luck = (int) GameData.data[playerClass]["luck"];

        UpdateAllTheThings.playerStatUpdate(this.GetComponent<PlayerStats>());

        currentHealth = maxHealth;
        GetComponent<Movement>().speed = GetComponent<Movement>().baseSpeed * runSpeedMult;
        
    }
	public void spawn(){
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

        GameData.data[playerClass]["exp"] = exp;
        if(exp >= expNeeded)
        {
			level++;
            levelsGained++;
            expNeeded = (int)Math.Floor(expNeeded * Math.Pow(1.01, (double)level)) + expNeeded; //TODO balence this formular just temp for now

            GameData.data[playerClass]["level"] = level;
            GameData.data[playerClass]["levelsGained"] = levelsGained;
            GameData.data[playerClass]["expNeeded"] = expNeeded;
        }
    }
}
