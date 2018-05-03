using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

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
	}

	void openCharacterSheet(string character){
		Debug.Log ("Should open character sheet for " + character);

	}

}
