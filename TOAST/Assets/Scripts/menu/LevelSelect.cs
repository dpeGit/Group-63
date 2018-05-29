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
        GetComponent<ProceduralGeneration>().generation();
        Doors.location = new int[2] {7 , 7};
        PlayerStats.spawnPoint = 4;
        SceneManager.LoadScene(4);
    }



	public void back(){
		SceneManager.LoadScene (0);
	}
}
