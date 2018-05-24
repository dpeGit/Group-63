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

	private GameObject[] incrementers = new GameObject[6];
	private GameObject[] decrementers = new GameObject[6];
	private int[] pointsAdded = new int[6];
	private int points;
    string selected;

	// Use this for initialization
	void Start () {
        SaveLoad.load();
        if (character == "Knight")
            selected = "knight";
        else if (character == "Theif")
            selected = "rogue";
        else if (character == "Warrior")
            selected = "warrior";
        else if (character == "Mage")
            selected = "wizard";
        else if (character == "Archer")
            selected = "archer";

        for (int i = 0; i < 6; i++) {
			incrementers[i] = GameObject.Find("IncrementButton" + (i+1));
			decrementers[i] = GameObject.Find("DecrementButton" + (i+1));
			pointsAdded [i] = 0;
		}
		charDisplay.text = character;
        points = (int)gameData.test[selected]["levelsGained"];
		updateDisplay ();
		pointsCheck ();
	}

	public void increment(string stat) {
        gameData.test[selected][stat] = (int)gameData.test[selected][stat] + 1;
 

		switch (stat) {
		case "strength":
			pointsAdded [0]++;
			break;
		case "agility":
			pointsAdded [1]++;
			break;
		case "armour":
			pointsAdded [2]++;
			break;
		case "intellect":
			pointsAdded [3]++;
			break;
		case "vitality":
			pointsAdded [4]++;
			break;
		case "luck":
			pointsAdded [5]++;
			break;
		}
        points--;
		updateDisplay ();
		pointsCheck ();
	}

	public void decrement(string stat) {
        gameData.test[selected][stat] = (int)gameData.test[selected][stat] + 1;

  		switch (stat) {
		case "strength":
			pointsAdded [0]--;
			break;
		case "agility":
			pointsAdded [1]--;
			break;
		case "armour":
			pointsAdded [2]--;
			break;
		case "intellect":
			pointsAdded [3]--;
			break;
		case "vitality":
			pointsAdded [4]--;
			break;
		case "luck":
			pointsAdded [5]--;
			break;
		}
        points++;
		updateDisplay ();
		pointsCheck ();
	}

	public void lockIn(){
        gameData.test[selected]["levelsGained"] = (int)gameData.test[selected]["levelsGained"] - ((int)gameData.test[selected]["levelsGained"] - points);

		for (int i = 0; i < 6; i++) {
			pointsAdded [i] = 0;
		}
		points = (int)gameData.test[selected]["levelsGained"];
		updateDisplay ();
		pointsCheck ();
        SaveLoad.save();
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
		strength.text = gameData.test[selected]["strength"].ToString ();
		agility.text = gameData.test[selected]["agility"].ToString();
		intellect.text = gameData.test[selected]["intellect"].ToString();
		vitality.text = gameData.test[selected]["vitality"].ToString();
		armour.text = gameData.test[selected]["armour"].ToString();
		luck.text = gameData.test[selected]["luck"].ToString();
		pointsText.text = points.ToString ();
	}

	public void back(){
		SceneManager.LoadScene (2);
	}


}





