using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth : MonoBehaviour {

    public float stealthCD;
    public float stealthLength;

    private float timerTillStealth;
    private float stealthTimer;
    private float oldHealth;
    private bool isStealth;
    private PlayerStats stats;

    private void Start()
    {
        timerTillStealth = 0;
        stats = GetComponent<PlayerStats>();
        
    }


    void Update () {
        if(!isStealth)
        {
            notStealthed();
        }
        else
        {
            stealth();
        }
	}

    private void notStealthed()
    {
        if (oldHealth == stats.currentHealth)
        {
            timerTillStealth -= Time.deltaTime;
        }
        else
        {
            oldHealth = stats.currentHealth;
            timerTillStealth = stealthCD;
            Debug.Log("you got hit");
        }

        if(timerTillStealth <= 0)
        {
            isStealth = true;
            timerTillStealth = stealthCD;
            stealthTimer = stealthLength;
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemys){
                enemy.SendMessage("stun", stealthLength);
            }
            Debug.Log("Entering Stealth");
        }
    }

    private void stealth()
    {
        if(stealthTimer <= 0)
        {
            isStealth = false;
            Debug.Log("Leaving Stealth");
        }
        else
        {
            stealthTimer -= Time.deltaTime;
        }
    }
}
