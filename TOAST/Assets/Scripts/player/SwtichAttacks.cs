using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwtichAttacks : MonoBehaviour {

    private GameObject weapon1;
    private GameObject weapon2;

    private void Start()
    {
        weapon1 = GameObject.Find("axe");
        weapon2 = GameObject.Find("dagger");
        weapon1.SetActive(true);
        weapon2.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }
	}
}
