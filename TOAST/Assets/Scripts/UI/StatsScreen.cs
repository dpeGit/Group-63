using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MonoBehaviour {

	public string character;
	public Text strength, agility, intellect, vitality, armour, luck;
	public GameObject Knight;
	public GameObject Theif;
	public GameObject Warrior;
	public GameObject Mage;
	public GameObject Archer;
	GameObject selected;
	PlayerStats stats;

	// Use this for initialization
	void Start () {
		if (character == "Knight")
			selected = Knight;
		else if (character == "Theif")
			selected = Theif;
		else if (character == "Warrior")
			selected = Warrior;
		else if (character == "Mage")
			selected = Mage;
		else if (character == "Archer")
			selected = Archer;
		stats = selected.GetComponent<PlayerStats> ();
		updateDisplay ();
	}

	public void increment(string stat) {
		switch (stat) {
		case "strength":
			stats.strength++;
			break;
		case "agility":
			stats.agility++;
			break;
		case "intellect":
			stats.intellect++;
			break;
		case "vitality":
			stats.vitality++;
			break;
		case "armour":
			stats.armour++;
			break;
		case "luck":
			stats.luck++;
			break;
		}

		updateDisplay ();
	}

	void updateDisplay(){
		strength.text = stats.strength.ToString ();
		agility.text = stats.agility.ToString ();
		intellect.text = stats.intellect.ToString ();
		vitality.text = stats.vitality.ToString ();
		armour.text = stats.armour.ToString ();
		luck.text = stats.luck.ToString ();
	}



}





