using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regenHP : MonoBehaviour {

    public float regenCD;
    public float regenAmount;

    private float regenTimer = 0;
    private PlayerStats stats;


    private void Start()
    {
        stats = GetComponent<PlayerStats>();
        regenTimer = regenCD;
    }
    void Update () {
		if(regenTimer <= 0)
        {
            regenTimer = regenCD;
            stats.currentHealth += (int) (regenAmount * stats.maxHealth);
            if(stats.currentHealth > stats.maxHealth)
            {
                stats.currentHealth = stats.maxHealth;
            }

        }
        else
        {
            regenTimer -= Time.deltaTime;
        }
	}
}
