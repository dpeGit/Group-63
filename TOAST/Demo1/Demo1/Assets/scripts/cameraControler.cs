using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour
{
    public GameObject player;
    public float centerTime;

    private Vector2 offset;
    private Vector2 velocity = Vector2.zero;
    private float lastInput;

    public void Update()
    {
        if (player.GetComponent<CharacterController>().velocity == Vector3.zero && Time.time - lastInput > 0.05f )
        {
            offset = Vector2.SmoothDamp(transform.position, player.transform.position, ref velocity, centerTime, float.MaxValue ,Time.deltaTime);
            transform.position = offset;
        }
        else if (Vector2.Distance(player.transform.position, transform.position) < 3.5)
        {
            offset = transform.position - player.transform.position;
        }
        else
        {
            transform.position = (Vector2)player.transform.position + offset;
        }

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            lastInput = Time.time;
        }
    }
}