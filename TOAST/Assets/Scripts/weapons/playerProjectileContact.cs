using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectileContact : MonoBehaviour {

    public float projectileDamage;
    public float projectileKnockback;

    private float[] hitPackage;

	// Use this for initialization
	void Start () {
        hitPackage = new float[2];
        hitPackage[0] = projectileDamage;
        hitPackage[1] = projectileKnockback;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            other.SendMessage("damage", hitPackage);
            Destroy(this.gameObject);
        }
        else if (other.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
