using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    PlayerStats playerStats;

    public GameObject player;
    public Slider expSlider, hpSlider, manaSlider;
    public Text level, exp, expNeeded;
    public Text hp, maxhp, mana, maxmana;

	
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
		playerStats = player.GetComponent<PlayerStats> ();
    }

	void Update () {
        expSlider.value = (playerStats.exp / (float)playerStats.expNeeded) * 100;
        level.text = playerStats.level.ToString();
        exp.text = playerStats.exp.ToString();
        expNeeded.text = playerStats.expNeeded.ToString();

        hpSlider.value = (playerStats.currentHealth / (float)playerStats.maxHealth) * 100;
        hp.text = playerStats.currentHealth.ToString();
        maxhp.text = playerStats.maxHealth.ToString();

		manaSlider.value = (playerStats.currentMana / (float)playerStats.maxMana) * 100;
		mana.text = playerStats.currentMana.ToString();
		maxmana.text = playerStats.maxMana.ToString();
    }
}
