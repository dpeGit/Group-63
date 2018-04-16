using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour {

    GameObject[] weapons = new GameObject[15];
    GameObject[] Armor = new GameObject[15];

    public GameObject empty;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            weapons[i] = empty;
            Armor[i] = empty;

        }
    }

    void updateInv()
    {

    }

    private int findFirstEmpty(GameObject[] inv)
    {
        for (int i = 0; i < 15; i++)
        {
            if (inv[i].CompareTag("empty"))
                return i;
        }
        return -1;
    }

    void onPickup(GameObject item)
    {
<<<<<<< HEAD
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

    }

=======
       // if (item.tag == "weapon")
            //Array.find[]
    }

>>>>>>> 252c2c4cf03459ebc9377e682c40ca9944979810
}
