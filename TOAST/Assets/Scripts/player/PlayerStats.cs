using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int exp, expNeeded;
    public int level;

	// Use this for initialization
	void Start () {
        exp = 0;
        expNeeded = 1000;
        level = 1;
	}
        

	void Update () {
        //leveling
        if (exp >= expNeeded)
        {
            level++;
            exp = exp % expNeeded;
            expNeeded += 1000;
        }
    }
}
