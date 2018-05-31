using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("player"))
			Inventory.itemToPickup = gameObject;
		Debug.Log (Inventory.itemToPickup);
	}
}
