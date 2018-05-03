using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour {

    public int upperbound;
    public int lowerbound;

    [HideInInspector]
    static public int[,] mapLayout;

    private int numRooms;

    // put this script in a button for loading a level
    void Start () {
        numRooms = 1;
        Random.InitState(1);//testing thing only delete this for actual gameplay
	}

    //creates a 15x15 grid then randomly places rooms within said grid
    public void generation()
    {
        mapLayout = new int[15, 15];

        mapLayout[7, 7] = 3;

        spawnRooms(7, 7, 1);

        //this randomly looks for an available room and assignes it to the end this can be mondified if we want the end to spawn in the more spesific location
        while (true)
        {
            int x = Random.Range(0, 15);
            int y = Random.Range(0, 15);
            if (mapLayout[x, y] == 1)
            {
                mapLayout[x, y] = 4;
                break;
            }
        }

        //randomly assignes all remains available rooms to the enemy rooms. TODO right now there are only 2 basic bitch rooms as we create more we will need to modify the Random.Range down there to accomidate
        for(int i = 0; i < 15; i++)
        {
            for(int k = 0; k < 15; k++)
            {
                if (mapLayout[k, i] == 1) mapLayout[k, i] = Random.Range(5, 7);
            }
        }

        //printing grid till we have actual room assembly
        string test = "";
        for(int i  = 0; i < 15; i++)
        {
            for(int k = 0; k < 15; k++)
            {
                test += mapLayout[k, i] + " ";
            }
            test += "\n";
        }
        Debug.Log(test);
        Debug.Log(numRooms);

    }

    //gives it a location of a room at x and y and the length of the branch its on determines if a room should be placed at a location adjacent to current room
    private void spawnRooms(int x, int y, int branchLength)
    {
        //finds if there is a free space and adds it to a list
        List<int> freeSpaces = new List<int>();
        if(x > 0)
        {
            if (mapLayout[x - 1, y] == 0) freeSpaces.Add(0);
        }
        if (x < 14)
        {
            if (mapLayout[x + 1, y] == 0) freeSpaces.Add(1);
        }
        if (y > 0)
        {
            if (mapLayout[x, y - 1] == 0) freeSpaces.Add(2);
        }
        if (y < 14)
        {
            if (mapLayout[x, y + 1] == 0) freeSpaces.Add(3);
        }

        int[] freeSpacesArr = freeSpaces.ToArray();
        shuffleArray(freeSpacesArr); //shuffles the free locations to determine which order they should be computed
        List<int[]> newRooms = new List<int[]>();
        foreach (int i in freeSpacesArr) //for every free space it checks the direction then rolls to see if a room should be placed here
        {
            //Used a swtich case here because it is clean and easier for checking one variable on multple conditions
            switch (i)
            {
                case 0:
                    if (rollDice(branchLength)) { mapLayout[x - 1, y] = 1; numRooms++; newRooms.Add(new int[2] { x - 1, y }); }

                    break;
                case 1:
                    if (rollDice(branchLength)) { mapLayout[x + 1, y] = 1; numRooms++; newRooms.Add(new int[2] { x + 1, y }); }

                    break;
                case 2:
                    if (rollDice(branchLength)) { mapLayout[x, y - 1] = 1; numRooms++; newRooms.Add(new int[2] { x, y - 1 }); }
                    break;
                case 3:
                    if (rollDice(branchLength)) { mapLayout[x, y + 1] = 1; numRooms++; newRooms.Add(new int[2] { x, y + 1 }); }
                    break;
                default:
                    break;
            }
        }

        foreach(int[] i in newRooms)
        {
            spawnRooms(i[0], i[1], branchLength + 1);//recursivly creates new rooms
        }

    }

    //modify this to cahnge how rooms would be place. For example one could bais it to not place a room if there are multiple adjecent rooms already which would create longer corridors instead of boxy shapes
    private bool rollDice(int branchLength)
    {
        if (numRooms < lowerbound && branchLength <= 7)//if we are below the lowerbound for rooms then always place one except when the branch would be longer than 7
        {
            return true;
        }
        else if (numRooms >= upperbound || branchLength > 7)//if at uper bound or a branch longer than 7 never place a room there
        {
            return false;
        }
        else
        {
           return 100 > Random.Range(0, 100) * Mathf.Pow(branchLength, 0.5f);//otherwise roll a dice if the number is lower than 100 place a room baised so that the longer the branch the "harder" it is to place a room
        }

    }

    //standard shuffle function
    private static void shuffleArray(int[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            int tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }
}
