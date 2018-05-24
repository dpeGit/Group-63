using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour {

	public GameObject room;
	private int[,] map;
	private int[] location;
	private GameObject[,] rooms;
	private GameObject[,] layout;
	private Vector3 verticalSpacing, horizontalSpacing;
	private int rows, cols;
	GameObject currentRoom;


	void Start (){
		
		GetComponent<ProceduralGeneration>().generation();
		map = ProceduralGeneration.mapLayout;
		rows = map.GetLength (0);
		cols = map.GetLength (1);
		rooms = ProceduralGeneration.rooms;
		location = Doors.location;
		spawnRooms ();
		currentRoom = rooms [location [0], location [1]];
	}

	void update(){
		if (Doors.locationChanged) {
			Doors.locationChanged = false;
			currentRoom.SetActive (false);
			currentRoom = rooms [location [0], location [1]];
			currentRoom.SetActive (true);
		}
		
	}




	void spawnRooms (){
		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				layout[r,c] = Instantiate(rooms[r, c], Vector3.zero, new Quaternion(0,0,0,0));
			}
		}

	}


}
