using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsScreen : MonoBehaviour {

    public static string character;
    public Text strength, agility, intellect, vitality, luck, pointsText;
    public Text charDisplay;
    public GameObject Knight;
    public GameObject Theif;
    public GameObject Warrior;
    public GameObject Mage;
    public GameObject Archer;

    private GameObject[] incrementers = new GameObject[5];
    private GameObject[] decrementers = new GameObject[5];
    private int[] pointsAdded = new int[5];
    private int points;
    string selected;

    // Use this for initialization
    void Start()
    {
        if (character == "Knight")
            selected = "knight";
        else if (character == "Theif")
            selected = "theif";
        else if (character == "Warrior")
            selected = "warrior";
        else if (character == "Mage")
            selected = "mage";
        else if (character == "Archer")
            selected = "archer";

        for (int i = 0; i < 5; i++)
        {
            incrementers[i] = GameObject.Find("IncrementButton" + (i + 1));
            decrementers[i] = GameObject.Find("DecrementButton" + (i + 1));
            pointsAdded[i] = 0;
        }
        charDisplay.text = character;
        points = (int)GameData.data[selected]["levelsGained"];
        updateDisplay();
        pointsCheck();
    }

    public void increment(string stat)
    {
        GameData.data[selected][stat] = (int)GameData.data[selected][stat] + 1;


        switch (stat)
        {
            case "strength":
                pointsAdded[0]++;
                break;
            case "agility":
                pointsAdded[1]++;
                break;
            case "intellect":
                pointsAdded[2]++;
                break;
            case "vitality":
                pointsAdded[3]++;
                break;
            case "luck":
                pointsAdded[4]++;
                break;
        }
        points--;
        updateDisplay();
        pointsCheck();
    }

    public void decrement(string stat)
    {
        GameData.data[selected][stat] = (int)GameData.data[selected][stat] + 1;

        switch (stat)
        {
            case "strength":
                pointsAdded[0]--;
                break;
            case "agility":
                pointsAdded[1]--;
                break;
            case "intellect":
                pointsAdded[2]--;
                break;
            case "vitality":
                pointsAdded[3]--;
                break;
            case "luck":
                pointsAdded[4]--;
                break;
        }
        points++;
        updateDisplay();
        pointsCheck();
    }

    public void lockIn()
    {
        GameData.data[selected]["levelsGained"] = (int)GameData.data[selected]["levelsGained"] - ((int)GameData.data[selected]["levelsGained"] - points);

        for (int i = 0; i < 5; i++)
        {
            pointsAdded[i] = 0;
        }
        points = (int)GameData.data[selected]["levelsGained"];
        updateDisplay();
        pointsCheck();
        SaveLoad.save();
    }

    void pointsCheck()
    {
        //Check to see if all the points are used. If they are, deactivate buttons
        if (points <= 0)
        {
            for (int i = 0; i < 5; i++)
            {
                incrementers[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                incrementers[i].SetActive(true);
            }
        }
        //Check to see if a stat has been increased. If it has, activate decrease buttons

        for (int i = 0; i < 5; i++)
        {
            if (pointsAdded[i] > 0)
            {
                decrementers[i].SetActive(true);
            }
            else
            {
                decrementers[i].SetActive(false);
            }
        }

    }

    void updateDisplay()
    {
        strength.text = GameData.data[selected]["strength"].ToString();
        agility.text = GameData.data[selected]["agility"].ToString();
        intellect.text = GameData.data[selected]["intellect"].ToString();
        vitality.text = GameData.data[selected]["vitality"].ToString();
        luck.text = GameData.data[selected]["luck"].ToString();
        pointsText.text = points.ToString();
    }

    public void back()
    {
        SceneManager.LoadScene(2);
    }
}