using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject Panel;
    bool paused;

	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (paused)
            {
                Panel.gameObject.SetActive(false);
                paused = false;
            }
            else
            {
                Panel.gameObject.SetActive(true);
                paused = true;
            }
        }
	}

    public void Resume()
    {
        Panel.gameObject.SetActive(false);
        paused = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
