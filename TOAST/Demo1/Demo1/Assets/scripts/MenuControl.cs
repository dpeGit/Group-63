using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {
    
    public void loadGame()  
    {
        SceneManager.LoadScene("game");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
