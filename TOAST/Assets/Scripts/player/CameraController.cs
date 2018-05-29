using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public SpriteRenderer cameraBounds;

    private float rightBound, leftBound, upperBound, lowerBound;
    private GameObject player;

    // Finds the bounds of the floor
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("player");

        cameraBounds = GameObject.FindGameObjectWithTag("floor").GetComponent<SpriteRenderer>();

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        //TODO replace floorScale(X,Y) with somehting that automatically grabs floor and wall scales
        leftBound = horzExtent - cameraBounds.sprite.bounds.size.x * (cameraBounds.transform.lossyScale.x / 2f);
        rightBound = cameraBounds.sprite.bounds.size.x * (cameraBounds.transform.lossyScale.x / 2f) - horzExtent;
        lowerBound = vertExtent - cameraBounds.sprite.bounds.size.y * (cameraBounds.transform.lossyScale.y / 2f);
        upperBound = cameraBounds.sprite.bounds.size.y * (cameraBounds.transform.lossyScale.y / 2f) - vertExtent;
    }
	
	// Sets the camera to the player's position unless it would move outside of the bounds
	void Update ()
    {
        Vector2 position = player.transform.position;
        position.x = Mathf.Clamp(position.x, leftBound, rightBound);
        position.y = Mathf.Clamp(position.y, lowerBound, upperBound);
        transform.position = position;
	}
}
