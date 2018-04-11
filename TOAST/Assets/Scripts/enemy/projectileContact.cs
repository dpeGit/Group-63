using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileContact : MonoBehaviour {

    public float projectileDamage;


	// Use this for initialization
	void Start () {
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            other.SendMessage("playerDamage", projectileDamage);
            Destroy(this.gameObject);
        }
        else if (other.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
