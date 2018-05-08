using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MonoBehaviour {

	public static string character;
	public Text strength, agility, intellect, vitality, armour, luck, pointsText;
	public Text charDisplay;
	public GameObject Knight;
	public GameObject Theif;
	public GameObject Warrior;
	public GameObject Mage;
	public GameObject Archer;
	GameObject selected;
	PlayerStats stats;

	private GameObject[] incrementers = new GameObject[7];
	private GameObject[] decrementers = new GameObject[7];
	private int points;

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
		
		for (int i = 1; i < 7; i++) {
			incrementers[i] = GameObject.Find("IncrementButton" + i);
			decrementers[i] = GameObject.Find("DecrementButton" + i);
		}

		stats = selected.GetComponent<PlayerStats> ();
		charDisplay.text = character;
		points = stats.levelsGained;
		updateDisplay ();
		pointsCheck ();
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
		points--;
		updateDisplay ();
		pointsCheck ();
	}

	public void decrement(string stat) {
		switch (stat) {
		case "strength":
			stats.strength--;
			break;
		case "agility":
			stats.agility--;
			break;
		case "intellect":
			stats.intellect--;
			break;
		case "vitality":
			stats.vitality--;
			break;
		case "armour":
			stats.armour--;
			break;
		case "luck":
			stats.luck--;
			break;
		}
		points++;
		updateDisplay ();
		pointsCheck ();
	}

	public void lockIn(){
		stats.levelsGained -= (stats.levelsGained - points);
	}

	void pointsCheck(){
		if (points <= 0) {
			for (int i = 1; i < 7; i++) {
				incrementers [i].SetActive (false);
			}
		} 
		else {
			for (int i = 1; i < 7; i++) {
				incrementers [i].SetActive (true);
			}
		}
		if (points >= stats.levelsGained) {
			for (int i = 1; i <= 6; i++) {
				decrementers [i].SetActive (false);
			}
		} 
		else {
			for (int i = 1; i <= 6; i++) {
				decrementers [i].SetActive (true);
			}
		}
	}

	void updateDisplay(){
		strength.text = stats.strength.ToString ();
		agility.text = stats.agility.ToString ();
		intellect.text = stats.intellect.ToString ();
		vitality.text = stats.vitality.ToString ();
		armour.text = stats.armour.ToString ();
		luck.text = stats.luck.ToString ();
		pointsText.text = points.ToString ();
	}



}





