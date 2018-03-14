using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public void LoadCampfire()
    {
        SceneManager.LoadScene(2);
    }

	public void LoadTemple()
    {
        SceneManager.LoadScene(3);
    }

}
