using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public GameObject Panel;
    public bool paused;
    public Button ResumeButton, Temple;

	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (paused)
            {
                Panel.gameObject.SetActive(false);
                paused = false;
                Temple.Select();
            }
            else
            {
                Panel.gameObject.SetActive(true);
                paused = true;
                ResumeButton.Select();
            }
        }
        
	}

    public void Resume()
    {
        Panel.gameObject.SetActive(false);
        paused = false;
        Temple.Select();
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
