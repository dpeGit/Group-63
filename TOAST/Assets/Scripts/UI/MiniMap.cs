using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour {

	public GameObject mapArea;
	public GameObject rooms, start, end, blank, currentRoom;

	GridLayoutGroup grid;
	private int[,] map = ProceduralGeneration.mapLayout;
	private int[] location;
	private GameObject[,] minimap;
	int rows;
	int cols;

	void Start (){
		rows = map.GetLength (0);
		cols = map.GetLength (1);
		minimap = new GameObject[rows, cols];
		location = Doors.location;
		grid = mapArea.GetComponent<GridLayoutGroup> ();
		grid.cellSize = new Vector2 (150 / rows, 150 / cols);
		drawMinimap ();
		minimap [location [0], location [1]].GetComponent<Image> ().color = new Color (234, 210, 0);
	}

	void drawMinimap(){
		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				if (map [r, c] < 0)
					minimap [r, c] = Instantiate (blank, mapArea.transform);
				else {
					minimap [r, c] = Instantiate (rooms, mapArea.transform);
					if (map [r, c] == 1)
						minimap [r, c].GetComponent<Image>().color = new Color(255,0,0);
				}
			}
		}


	}

	public void changeMinimapLocation(){
	}

}
