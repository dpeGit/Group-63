using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    PlayerStats playerStats;

    public GameObject player;
    public Slider expSlider, hpSlider, manaSlider;
	public Text level;

	
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
		playerStats = player.GetComponent<PlayerStats> ();
    }

	void Update () {
        expSlider.value = (playerStats.exp / (float)playerStats.expNeeded);
        level.text = playerStats.level.ToString();
        hpSlider.value = (playerStats.currentHealth / (float)playerStats.maxHealth);
		manaSlider.value = (playerStats.currentMana / (float)playerStats.maxMana);
    }
}
