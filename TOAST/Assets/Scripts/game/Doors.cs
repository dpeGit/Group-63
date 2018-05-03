using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Doors : MonoBehaviour {

    public int side;//the direction the door is in use 0 for west, 1 for east, 2 for south, 3 for north
    public int[] location;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            SceneManager.LoadScene(4);
        }
    }
}
