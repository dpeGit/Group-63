using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour {

    GameObject[] weapons = new GameObject[18];
    GameObject[] Armor = new GameObject[18];
    GameObject[] slots = new GameObject[18];
    
    public GameObject empty;
    public GameObject item;
    public bool interactable;
    //public GameObject equipped;

    private string currentInv = "";


    private void Start()
    {
        currentInv = "weapons";
        for (int i = 0; i < 18; i++)
        {
            slots[i] = GameObject.Find("Item" + (i+1));
            weapons[i] = empty;
            Armor[i] = empty;
        }
        updateInv();
    }

    public void optionSelected(int num)
    {
        if (slots[num].GetComponent<Dropdown>().value == 0)
            equip();
        if (slots[num].GetComponent<Dropdown>().value == 1)
            drop(num);
    }

    // called when an item is equiped
    public void equip()
    {

    }

    public void drop(int i)
    {
        weapons[i] = empty;
        shift();
        updateInv();
    }

    void shift()
    {
        if (currentInv.Equals("weapons"))
        {
            int i = 0;
            while (i < 17)
            {
                if (weapons[i] == empty && weapons[i + 1] != empty)
                {
                    weapons[i] = weapons[i + 1];
                    weapons[i + 1] = empty;
                }
                i += 1;
            }
        }
    }
    // called when an item is picked up
    public void onPickup(GameObject item)
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
        for (int i = 0; i < 18; i++)
        {
            slots[i].GetComponent<Dropdown>().value = 2;
            if (currentInv.Equals("weapons"))
            {
                if (weapons[i].CompareTag("empty"))
                {
                    slots[i].GetComponent<Dropdown>().enabled = false;
                    slots[i].GetComponent<Image>().overrideSprite = empty.GetComponent<Image>().sprite;
                    slots[i].GetComponent<Image>().color = empty.GetComponent<Image>().color;
                }
                else
                {
                    slots[i].GetComponent<Dropdown>().enabled = true;
                    slots[i].GetComponent<Image>().overrideSprite = weapons[i].GetComponent<SpriteRenderer>().sprite;
                    slots[i].GetComponent<Image>().color = weapons[i].GetComponent<SpriteRenderer>().color;
                }
                    

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
        for (int i = 0; i < 18; i++)
        {
            if (inv[i].CompareTag("empty"))
                return i;
        }
        return -1;
    }


}
