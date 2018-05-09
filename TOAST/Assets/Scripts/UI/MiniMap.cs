using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour {

	public GameObject mapArea;
	public GameObject rooms, start, end, blank;

	GridLayoutGroup grid;
	private int[,] map = ProceduralGeneration.mapLayout;
	int rows;
	int cols;

	void Start (){
		rows = map.GetLength (0);
		cols = map.GetLength (1);
		drawMinimap ();
		grid = mapArea.GetComponent<GridLayoutGroup> ();

		grid.cellSize = new Vector2 (150 / rows, 150 / cols);
	}

	void drawMinimap(){
		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				if (map[r,c] == 3)
					Instantiate (start, mapArea.transform);
				else if (map[r,c] == 4)
					Instantiate (end, mapArea.transform);
				else if (map[r,c] > 0)
					Instantiate (rooms, mapArea.transform);
				else
					Instantiate (blank, mapArea.transform);
			}
		}


	}
	

}
