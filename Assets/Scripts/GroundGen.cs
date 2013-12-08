using UnityEngine;
using System.Collections;

public class GroundGen : MonoBehaviour {
	
	public int coloumn, row;
	//public GameObject tile;
	public GameObject[] chunk;

	private int rowHalf,colHalf;
	

	// Use this for initialization
	void Start () {

		rowHalf = row/2;
		colHalf = coloumn/2;

		for(int i = 0; i < row; i++)
		{
			for (int n = 0; n < coloumn; n++)
			{
				GameObject chunkPlace;
				GameObject chunkPick = chunk[Random.Range(0,chunk.Length)];
				Vector3 placement = new Vector3(n*10,0,i*10);
				chunkPlace = Instantiate(chunkPick,placement,Quaternion.Euler(chunkPick.transform.rotation.eulerAngles)) as GameObject;
				chunkPlace.name = "Chunk "+i+", "+n;
				chunkPlace.transform.parent = this.transform;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
