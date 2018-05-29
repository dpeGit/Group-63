using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

	public static string CharacterSelected;

	public void optionSelected(string character){
		if (GameObject.Find (character).GetComponent<Dropdown> ().value == 0)
			selectCharacter (character);
		if (GameObject.Find (character).GetComponent<Dropdown> ().value == 1)
			openCharacterSheet (character);
		reset (character);

	}

	void reset(string c){
		GameObject.Find (c).GetComponent<Dropdown> ().value = 2;
	}

	void selectCharacter(string character){
		Debug.Log (character + " has been selected");
		CharacterSelected = character;
	}

	void openCharacterSheet(string character){
		Debug.Log ("Should open character sheet for " + character);
		StatsScreen.character = character;
		SceneManager.LoadScene (3);

	}



	public void back(){
		SceneManager.LoadScene (1);
	}

}
