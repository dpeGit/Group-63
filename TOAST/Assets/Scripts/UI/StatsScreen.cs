using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsScreen : MonoBehaviour {

	public static string character;
	public Text strength, agility, intellect, vitality, armour, luck, pointsText;
	public Text charDisplay;
	public GameObject Knight;
	public GameObject Theif;
	public GameObject Warrior;
	public GameObject Mage;
	public GameObject Archer;
    var selected;
	PlayerStats stats;

	private GameObject[] incrementers = new GameObject[6];
	private GameObject[] decrementers = new GameObject[6];
	private int[] pointsAdded = new int[6];
	private int points;

	// Use this for initialization
	void Start () {
        if (character == "Knight") {
            KnightDatas
        }
        else if (character == "Theif")
            RogueData selected;
        else if (character == "Warrior")
            WarriorData selected;
        else if (character == "Mage")
            WizzardData selected;
        else if (character == "Archer")
            ArcherData selected;

        for (int i = 0; i < 6; i++) {
			incrementers[i] = GameObject.Find("IncrementButton" + (i+1));
			decrementers[i] = GameObject.Find("DecrementButton" + (i+1));
			pointsAdded [i] = 0;
		}
		charDisplay.text = character;
		points = selected.
		updateDisplay ();
		pointsCheck ();
	}

	public void increment(string stat) {
		switch (stat) {
		case "strength":
			stats.strength++;
			pointsAdded [0]++;
			break;
		case "agility":
			stats.agility++;
			pointsAdded [1]++;
			break;
		case "armour":
			stats.armour++;
			pointsAdded [2]++;
			break;
		case "intellect":
			stats.intellect++;
			pointsAdded [3]++;
			break;
		case "vitality":
			stats.vitality++;
			pointsAdded [4]++;
			break;
		case "luck":
			stats.luck++;
			pointsAdded [5]++;
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
			pointsAdded [0]--;
			break;
		case "agility":
			stats.agility--;
			pointsAdded [1]--;
			break;
		case "armour":
			stats.armour--;
			pointsAdded [2]--;
			break;
		case "intellect":
			stats.intellect--;
			pointsAdded [3]--;
			break;
		case "vitality":
			stats.vitality--;
			pointsAdded [4]--;
			break;
		case "luck":
			stats.luck--;
			pointsAdded [5]--;
			break;
		}
		points++;
		updateDisplay ();
		pointsCheck ();
	}

	public void lockIn(){
		stats.levelsGained -= (stats.levelsGained - points);
		for (int i = 0; i < 6; i++) {
			pointsAdded [i] = 0;
		}
		points = stats.levelsGained;
		updateDisplay ();
		pointsCheck ();
	}

	void pointsCheck(){
		//Check to see if all the points are used. If they are, deactivate buttons
		if (points <= 0) {
			for (int i = 0; i < 6; i++) {
				incrementers [i].SetActive (false);
			}
		} 
		else {
			for (int i = 0; i < 6; i++) {
				incrementers [i].SetActive (true);
			}
		}
		//Check to see if a stat has been increased. If it has, activate decrease buttons

		for (int i = 0; i < 6; i++) {
			if (pointsAdded [i] > 0) {
				decrementers [i].SetActive (true);
			} 
			else {
				decrementers [i].SetActive (false);
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

	public void back(){
		SceneManager.LoadScene (2);
	}


}





