using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour {

    GameObject[] weapons = new GameObject[15];
    GameObject[] Armor = new GameObject[15];
    GameObject[] slots = new GameObject[15];
    
    public GameObject empty;
    public GameObject equipped;

    private string currentInv = "";


    private void Start()
    {
        currentInv = "weapons";
        for (int i = 0; i < 15; i++)
        {
            slots[i] = GameObject.Find("Item" + (i+1));
            weapons[i] = empty;
            Armor[i] = empty;
        }
        updateInv();
    }

    // called when an item is equiped
    void equip()
    {

    }

    // called when an item is picked up
    void onPickup(GameObject item)
    {
        int loc = 0;

        if (item.tag == "weapon")
        {
            loc = findFirstEmpty(weapons);
            if (loc >= 0)
                weapons[loc] = item;
        }

        if (item.tag == "armor")
        {
            loc = findFirstEmpty(Armor);
            if (loc >= 0)
                Armor[loc] = item;
        }
        updateInv();
    }


    // whenever an item is picked up or dropped, updateInv is called
    // updateInv makes it so that slots that have items are interactable, and slots that dont have items aren't
    void updateInv()
    {
        for (int i = 0; i < 15; i++)
        {
            if (currentInv.Equals("weapons"))
            {
                if (weapons[i].CompareTag("empty"))
                    slots[i].GetComponent<Dropdown>().enabled = false;
                else
                    slots[i].GetComponent<Dropdown>().enabled = true;
            }
            else if (currentInv.Equals("Armor"))
            {
                if (Armor[i].CompareTag("empty"))
                    slots[i].GetComponent<Dropdown>().enabled = false;
                else
                    slots[i].GetComponent<Dropdown>().enabled = true;

            }
        }

    }


    // finds first empty object in the invenory so that it can be replaced when an item is picked up
    private int findFirstEmpty(GameObject[] inv)
    {
        for (int i = 0; i < 15; i++)
        {
            if (inv[i].CompareTag("empty"))
                return i;
        }
        return -1;
    }


}
