using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAllTheThings : MonoBehaviour {

    public static void playerStatUpdate(PlayerStats player)
    {
        player.maxHealth = (int)(player.vitality * 20 * player.healthMult);
        player.maxMana = (int)(player.intellect * 30 * player.manaMult);
        player.GetComponent<Movement>().speed = player.GetComponent<Movement>().baseSpeed * player.runSpeedMult;
    }

    public static void weaponUpdate()
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
        foreach (GameObject weapon in weapons)
        {
            weapon.SendMessage("updateStats");
        }
    }
}
