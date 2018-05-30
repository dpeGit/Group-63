using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public GameObject Panel;
    public bool paused;
    public Button ResumeButton, ExitButton;


    private void Awake()
    {
        Time.timeScale = 1f;
    }

    //when escape is pressed pauses game or resumes it
    void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (paused)
            {
                Panel.gameObject.SetActive(false);
                paused = false;
                Time.timeScale = 1f;
				ExitButton.Select();
            }
            else
            {
                Panel.gameObject.SetActive(true);
                paused = true;
                Time.timeScale = 0f;
                ResumeButton.Select();
            }
        }
        
	}

    public void Resume()
    {
        Panel.gameObject.SetActive(false);
        paused = false;
        //Temple.Select();
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        GameObject.Destroy(GameObject.FindGameObjectWithTag("player"));
        SceneManager.LoadScene(1);
    }
}
