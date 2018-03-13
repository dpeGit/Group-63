using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwtichAttacks : MonoBehaviour {

    private SlashAttack attack1;
    private StabAttack attack2;

    private void Start()
    {
        attack1 = GetComponent<SlashAttack>();
        attack2 = GetComponent<StabAttack>();
        attack1.enabled = true;
        attack2.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            attack1.enabled = true;
            attack2.enabled = false;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            attack1.enabled = false;
            attack2.enabled = true;
        }
	}
}
