using UnityEngine;
using System.Collections;

public class MazeLoader : MonoBehaviour {
	public int mazeRows = 7, mazeColumns = 7;
	public GameObject wall;
	public float size = 6f;

	private MazeCell[,] mazeCells;

	// Use this for initialization
	void OnEnable () {		
		InitializeMaze ();
		MazeAlgorithm ma = new HuntAndKillMazeAlgorithm (mazeCells);
		ma.CreateMaze ();
	}

	void OnDisable() {
		DestroyMaze();
	}
	
	// Update is called once per frame
	void Update () {
	}

	

	private void InitializeMaze() {

		mazeCells = new MazeCell[mazeRows,mazeColumns];

		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++) {
				mazeCells [r, c] = new MazeCell ();

				// For now, use the same wall object for the floor!
				mazeCells [r, c] .floor = Instantiate (wall, new Vector3 (r*size, -(size/2f), c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c] .floor.name = "Floor " + r + "," + c;
				mazeCells [r, c] .floor.transform.Rotate (Vector3.right, 90f);

				if (c == 0) {
					mazeCells[r,c].westWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) - (size/2f)), Quaternion.identity) as GameObject;
					mazeCells [r, c].westWall.name = "West Wall " + r + "," + c;
				}

				mazeCells [r, c].eastWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) + (size/2f)), Quaternion.identity) as GameObject;
				mazeCells [r, c].eastWall.name = "East Wall " + r + "," + c;

				if (r == 0) {
					mazeCells [r, c].northWall = Instantiate (wall, new Vector3 ((r*size) - (size/2f), 0, c*size), Quaternion.identity) as GameObject;
					mazeCells [r, c].northWall.name = "North Wall " + r + "," + c;
					mazeCells [r, c].northWall.transform.Rotate (Vector3.up * 90f);
				}
				
				if (!(r == mazeRows-1 && c == mazeColumns-1)){
					mazeCells[r,c].southWall = Instantiate (wall, new Vector3 ((r*size) + (size/2f), 0, c*size), Quaternion.identity) as GameObject;
					mazeCells [r, c].southWall.name = "South Wall " + r + "," + c;
					mazeCells [r, c].southWall.transform.Rotate (Vector3.up * 90f);
				}
				
			}
		}
	}

	private void DestroyWallIfItExists(GameObject wall) {
		if (wall != null) {
			GameObject.Destroy (wall);
		}
	}

	public void DestroyMaze(){
		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++)
			{
				DestroyWallIfItExists(mazeCells[r, c].floor);
				DestroyWallIfItExists(mazeCells[r, c].southWall);
				DestroyWallIfItExists(mazeCells[r,c].westWall);
				DestroyWallIfItExists(mazeCells[r,c].eastWall);
				DestroyWallIfItExists(mazeCells[r,c].northWall);
			}
		}
	}
}
