using UnityEngine;
using System.Collections;

public class ChunkGen : MonoBehaviour {
	/// <summary>
	/// THIS IS STILL BROKEN
	/// </summary>
	public int column, row;
	public GameObject[] chunk;
	public GameObject [] chunkList;
	public int rowHalf,colHalf;

	private bool halfHit = false;
	public bool reverse = false;
	public int listCount;
	
	
	// Use this for initialization
	void Start () 
	{
		//Used for getting the mid point for a row or column
		//This will make even numbered point to the right side
		//Example: 6 mid point = 4, 8 mid point = 5
		rowHalf = row/2;
		rowHalf = (Mathf.RoundToInt(rowHalf)+1);
		colHalf = column/2;
		colHalf = (Mathf.RoundToInt(colHalf)+1);
		

		int list = row*column;
		chunkList = new GameObject[list];
		listCount -= 1;

		if (!reverse)
		{
			for(int r = 0; r < rowHalf; r++)
			{
				for (int c = 0; c < column; c++)
				{
					GameObject chunkPlace;
					GameObject chunkPick = chunk[Random.Range(0,chunk.Length)];
					Vector3 placement = new Vector3(c*10,0,r*10);

					if (c == (colHalf-1) && r == (rowHalf-1))
					{
						listCount++;
						reverse = true;
						chunkPlace = Instantiate(chunk[0],placement,Quaternion.Euler(transform.rotation.eulerAngles)) as GameObject;
						chunkPlace.name = "Chunk "+r+", "+c;
						chunkPlace.transform.parent = this.transform;
						chunkList[listCount] = chunkPlace;
						break;
					}
					else
					{
						listCount++;
						chunkPlace = Instantiate(chunkPick,placement,Quaternion.Euler(chunkPick.transform.rotation.eulerAngles)) as GameObject;
						chunkPlace.name = "Chunk "+r+", "+c;
						chunkPlace.transform.parent = this.transform;
						chunkList[listCount] = chunkPlace;
					}
				}
			}
		}
		if (reverse)
		{
			int revListCount = listCount;
			revListCount--;
			Vector3 revPlacement = chunkList[listCount].transform.position;
			int midNum = Mathf.RoundToInt((revPlacement.x/10));
			GameObject revChunkPlace;
			GameObject revChunkPick = chunkList[revListCount];
			//revPlacement = revChunkPick.transform.position;

			for (int c = 3; c < column; c++)
			{
				revPlacement.x = (((midNum - revPlacement.x)*2)+revPlacement.x)*10;
				revPlacement.z = (((midNum - revPlacement.z)*2)+revPlacement.z)*10;
				//Vector3 revPlaceRot = (revChunkPick.transform.localRotation.eulerAngles.y + 180);
				revChunkPlace = Instantiate(revChunkPick,revPlacement,Quaternion.Euler(revChunkPick.transform.rotation.eulerAngles)) as GameObject;

			}

			for(int r = 1; r < rowHalf; r++)
			{


				for (int c = 0; c < column; c++)
				{
						
						//revPlacement.x = (((midNum - revPlacement.x)*2)+revPlacement.x)*10;
						//revPlacement.z = (((midNum - revPlacement.z)*2)+revPlacement.z)*10;
						

				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
