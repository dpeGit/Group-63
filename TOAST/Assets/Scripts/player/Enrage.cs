using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enrage : MonoBehaviour {

    private PlayerStats stats;
    private float oldHealth;

	// Use this for initialization
	void Start () {
        stats = GetComponent<PlayerStats>();
        oldHealth = stats.currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if(oldHealth > stats.currentHealth)
        {
            stats.strength++;
            oldHealth = stats.currentHealth;
            UpdateAllTheThings.weaponUpdate();
        }
        else if(oldHealth != stats.currentHealth)
        {
            oldHealth = stats.currentHealth;
        }
	}
}
