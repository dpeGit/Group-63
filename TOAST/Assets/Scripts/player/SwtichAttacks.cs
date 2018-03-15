using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwtichAttacks : MonoBehaviour {

    private GameObject weapon1;
    private GameObject weapon2;

    //set variables enables weapon1 and disables weapon2
    private void Start()
    {
        weapon1 = GameObject.Find("axe");
        weapon2 = GameObject.Find("dagger");
        weapon1.SetActive(true);
        weapon2.SetActive(false);
    }

    // Swaps weapon based on key pressed
    void Update () {
        if (Input.GetKeyDown("1"))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);        }
        else if (Input.GetKeyDown("2"))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }
	}
}
