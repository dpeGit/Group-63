using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour {



    public  GameObject empty;
	public  GameObject equippedWeaponSlot, equippedArmorSlot;
    public  bool interactable;
	public  Text equippedName, compareName, equippedDescription, compareDescription;
	public static GameObject itemToPickup;
	public GameObject inventory;
	GameObject player;

    private  string currentInv = "";
	private  GameObject[] weapons = new GameObject[18];
	private  GameObject[] Armor = new GameObject[18];
	private  GameObject[] slots = new GameObject[18];
	private  GameObject equippedWeapon, equippedArmor;

	void Update () {
		if (itemToPickup.tag != "empty") {
			Debug.Log ("Pickup request recieved");
			GameObject item = itemToPickup;
			onPickup (item);
		}
	}

    private void Start()
    {
		player = GameObject.FindGameObjectWithTag ("player");
        currentInv = "weapons";
		inventory.SetActive(true);
        for (int i = 0; i < 18; i++)
        {
            slots[i] = GameObject.Find("Item" + (i+1));
            weapons[i] = empty;
            Armor[i] = empty;
        }
		itemToPickup = empty;

		equippedWeapon = player.transform.GetChild(0).gameObject;
		equippedWeaponSlot.GetComponent<Image>().overrideSprite = equippedWeapon.GetComponent<SpriteRenderer>().sprite;
		equippedWeaponSlot.GetComponent<Image>().color = equippedWeapon.GetComponent<SpriteRenderer>().color;

		equippedArmor = empty;
        updateInv();
		inventory.SetActive(false);
    }

	public void switchInv(string s)
	{
		currentInv = s;
		updateInv ();
	}

    public void optionSelected(int num)
    {
        if (slots[num].GetComponent<Dropdown>().value == 0)
            equip(num);
        if (slots[num].GetComponent<Dropdown>().value == 1)
            drop(num);
    }

    // called when an item is equiped
	public void equip(int n)
    {
		Debug.Log ("equip item in slot" + n);
		if (currentInv.Equals("weapons")){
			Debug.Log ("working");
			if (equippedWeapon != empty)
				onPickup (equippedWeapon);
			equippedWeapon = weapons [n];
			Instantiate (equippedWeapon, player.transform); 
			removeItem(n);
			equippedName.text = equippedWeapon.GetComponent<WeaponStats>().name;
			equippedDescription.text = equippedWeapon.GetComponent<WeaponStats>().description;
			equippedWeaponSlot.GetComponent<Image>().overrideSprite = equippedWeapon.GetComponent<SpriteRenderer>().sprite;
			equippedWeaponSlot.GetComponent<Image>().color = equippedWeapon.GetComponent<SpriteRenderer>().color;
		}
		else if (currentInv.Equals("Armor")){
			Debug.Log ("working");
			if (equippedArmor != empty)
				onPickup (equippedArmor);
			equippedArmor = Armor [n];
			Instantiate (equippedArmor, player.transform);
			removeItem(n);
			equippedName.text = equippedArmor.GetComponent<WeaponStats>().name;
			equippedDescription.text = equippedWeapon.GetComponent<WeaponStats>().description;
			equippedArmorSlot.GetComponent<Image>().overrideSprite = equippedWeapon.GetComponent<SpriteRenderer>().sprite;
			equippedArmorSlot.GetComponent<Image>().color = equippedWeapon.GetComponent<SpriteRenderer>().color;
		}


		updateInv ();
    }

	void removeItem(int i)
	{
		if (currentInv.Equals ("weapons")) {
			weapons [i] = empty;
			shift ();
			updateInv ();
		} 
		else if (currentInv.Equals ("Armor")) {
			Armor [i] = empty;
			shift ();
			updateInv ();
		}
	}

    public void drop(int i)
	{
		if (currentInv.Equals ("weapons")) {
			Instantiate (weapons [i], player.transform.position, new Quaternion(0,0,0,0));
			weapons [i] = empty;
			shift ();
			updateInv ();
		} 
		else if (currentInv.Equals ("Armor")) {
			Instantiate (Armor [i], player.transform.position, new Quaternion(0,0,0,0));
			Armor [i] = empty;
			shift ();
			updateInv ();
		}
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
		else if (currentInv.Equals("Armor"))
		{
			int i = 0;
			while (i < 17)
			{
				if (Armor[i] == empty && Armor[i + 1] != empty)
				{
					Armor[i] = Armor[i + 1];
					Armor[i + 1] = empty;
				}
				i += 1;
			}
		}
    }

    // called when an item is picked up
    public  void onPickup(GameObject item)
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

		itemToPickup = empty;
		item.SetActive (false);
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
				if (Armor [i].CompareTag ("empty")) {
					slots [i].GetComponent<Dropdown> ().enabled = false;
					slots [i].GetComponent<Image> ().overrideSprite = empty.GetComponent<Image> ().sprite;
					slots [i].GetComponent<Image> ().color = empty.GetComponent<Image> ().color;
				} 
				else {
					slots [i].GetComponent<Dropdown> ().enabled = true;
					slots [i].GetComponent<Image> ().overrideSprite = Armor [i].GetComponent<SpriteRenderer> ().sprite;
					slots [i].GetComponent<Image> ().color = Armor [i].GetComponent<SpriteRenderer> ().color;
				}

            }
        }
		if (equippedWeapon == empty)
			equippedWeaponSlot.GetComponent<Dropdown> ().enabled = false;
		else
			equippedWeaponSlot.GetComponent<Dropdown> ().enabled = true;

		if (equippedArmor == empty)
			equippedArmorSlot.GetComponent<Dropdown> ().enabled = false;
		else
			equippedArmorSlot.GetComponent<Dropdown> ().enabled = true;
    }


    // finds first empty object in the invenory so that it can be replaced when an item is picked up
    private  int findFirstEmpty(GameObject[] inv)
    {
        for (int i = 0; i < 18; i++)
        {
            if (inv[i].CompareTag("empty"))
                return i;
        }
        return -1;
    }

	public void displayText(int n)
	{
		if (currentInv.Equals("weapons")) {
			compareName.text = weapons [n].GetComponent<WeaponStats> ().name;
			compareDescription.text = weapons [n].GetComponent<WeaponStats> ().description;
		}
		else if (currentInv.Equals("Armor")) {
			compareName.text = Armor [n].GetComponent<WeaponStats> ().name;
			compareDescription.text = Armor [n].GetComponent<WeaponStats> ().description;
		}
	}


}
