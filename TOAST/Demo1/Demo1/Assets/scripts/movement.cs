using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float speed;

    private CharacterController player;

	// Use this for initialization
	void Start () {
        player = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHoriz, moveVert);

        player.Move(movement * speed);
    }
}
