using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler2 : MonoBehaviour {

    public SpriteRenderer cameraBounds;
    public GameObject player;
    public float floorScaleX;
    public float floorScaleY;

    private float rightBound, leftBound, upperBound, lowerBound;

    // Use this for initialization
    void Start ()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        leftBound =  horzExtent - cameraBounds.sprite.bounds.size.x * (floorScaleX / 2f);
        rightBound = cameraBounds.sprite.bounds.size.x * (floorScaleX / 2f) - horzExtent;
        lowerBound = vertExtent - cameraBounds.sprite.bounds.size.y * (floorScaleY / 2f);
        upperBound = cameraBounds.sprite.bounds.size.y * (floorScaleY / 2f) - vertExtent;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 position = player.transform.position;
        position.x = Mathf.Clamp(position.x, leftBound, rightBound);
        position.y = Mathf.Clamp(position.y, lowerBound, upperBound);
        transform.position = position;
	}
}
