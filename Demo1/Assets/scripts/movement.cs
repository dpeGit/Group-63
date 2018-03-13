using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float speed;

    private Rigidbody2D player;
    private Vector2 playerMovement;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        if (moveHoriz == 0 && moveVert == 0)
        {
            player.velocity = Vector2.zero;
        }
        else
        {
            playerMovement = new Vector2(moveHoriz, moveVert);
            if (playerMovement.magnitude > 1 || playerMovement.magnitude < -1)
            {
                playerMovement.Normalize();
            }
            player.velocity = playerMovement * speed;
        }
    }
}
