using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour {

	public GameObject rooms, start, end, blank, currentRoom;

	private int[,] map = ProceduralGeneration.mapLayout;
	private int[] location;
	private Vector2 verticalSpacing, horizontalSpacing;
	int rows;
	int cols;

	void Start (){
		rows = map.GetLength (0);
		cols = map.GetLength (1);
		location = Doors.location;
		spawnRooms ();
		verticalSpacing = new Vector2 (0, 4);
		horizontalSpacing = new Vector2 (4, 0);
	}

	void spawnRooms (){
		location = new Vector2 (0, 0);
		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				if (r == location [0] && c == location [1])
					Instantiate (currentRoom, location);
				else if (map[r,c] == 3)
					Instantiate (start, location);
				else if (map[r,c] == 4)
					Instantiate (end, location);
				else if (map[r,c] > 0)
					Instantiate (rooms, location);
				else
					Instantiate (blank, location);
				location += verticalSpacing;
			}
			location = Vector2 (0, 0);
			location += r * horizontalSpacing;
		}
	}


}
