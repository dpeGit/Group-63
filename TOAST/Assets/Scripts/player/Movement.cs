using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour {

    public float baseSpeed, speed;

    private Rigidbody2D player;
    private Vector2 playerMovement;

	// Sets variables
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}

    //grabs user input and sets player velocity
    void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        //if there is no inputs velocity is set to 0 to avoid ice skakting
        if (moveHoriz == 0 && moveVert == 0)
        {
            player.velocity = Vector2.zero;
        }
        else
        {
            playerMovement = new Vector2(moveHoriz, moveVert);
            if (playerMovement.magnitude > 1 || playerMovement.magnitude < -1) //TODO i think this will be a problem with a gamepad giving axis inputs < 1 unsure
            {
                playerMovement.Normalize();
            }
            player.velocity = playerMovement * speed;
        }
    }
}
