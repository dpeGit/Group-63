using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoad : MonoBehaviour {

	public GameObject Knight;
	public GameObject Theif;
	public GameObject Warrior;
	public GameObject Mage;
	public GameObject Archer;
	string character = CharacterSelect.CharacterSelected;

	void Awake () {
        if (GameObject.FindGameObjectWithTag("player") == null)
        {
            if (character == "Knight")
                Instantiate(Knight);
            else if (character == "Theif")
                Instantiate(Theif);
            else if (character == "Warrior")
                Instantiate(Warrior);
            else if (character == "Mage")
                Instantiate(Mage);
            else if (character == "Archer")
                Instantiate(Archer);
            else if (character == null)
            {
                Instantiate(Knight);
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag("player").SendMessage("spawn");
        }
	}

}
