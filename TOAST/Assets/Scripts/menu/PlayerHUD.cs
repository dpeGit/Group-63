using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    PlayerStats playerStats;

    public GameObject player;
    public Slider expSlider;
    public Text level, exp, expNeeded;
	
    void Start()
    {
        player = GameObject.Find("player");
        playerText = player.GetComponent<PlayerStats>();
    }

	void Update () {
        expSlider.value = playerStats.exp / playerStats.expNeeded * 100;
        level.text = playerStats.level.ToString();
        exp.text = playerStats.exp.ToString();
        expNeeded.text = playerStats.expNeeded.ToString();
	}
}
