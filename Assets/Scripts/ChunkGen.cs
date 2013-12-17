using UnityEngine;
using System.Collections;

public class ChunkGen : MonoBehaviour {
	/// <summary>
	/// This now works, just needs the chunks to rotate during the reverse step
	/// of the generation, but this requires the way all the chunks are built 
	/// to be re-done
	/// </summary>
	public int column, row;
	public GameObject[] chunkPrefabs;
	public GameObject [] chunkList;
	public GameObject redSpawn,redCollection;
	public GameObject blueSpawn,blueCollection;
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
					GameObject chunkPick = chunkPrefabs[Random.Range(0,chunkPrefabs.Length)];
					Vector3 placement = new Vector3(c*10,0,r*10);

					if (c == (colHalf-1) && r == (rowHalf-1))
					{
						listCount++;
						reverse = true;
						chunkPlace = Instantiate(chunkPrefabs[0],placement,Quaternion.Euler(transform.rotation.eulerAngles)) as GameObject;
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
			Vector3 revPlacement = chunkList[listCount].transform.position;
			int midNum = Mathf.RoundToInt((revPlacement.x));
			revListCount--;
			GameObject revChunkPlace;
			GameObject revChunkPick;


			for (int c = colHalf; c < column; c++)
			{
				listCount++;
				revChunkPick = chunkList[revListCount];
				revPlacement = revChunkPick.transform.position;
				revPlacement.x = (((midNum - revPlacement.x)*2)+revPlacement.x);
				//Vector3 revPlaceRot = (revChunkPick.transform.localRotation.eulerAngles.y + 180);
				revChunkPlace = Instantiate(revChunkPick,revPlacement,Quaternion.Euler(revChunkPick.transform.rotation.eulerAngles)) as GameObject;
				revChunkPlace.name = "Chunk "+midNum/10+", "+c;
				revChunkPlace.transform.parent = this.transform;
				chunkList[listCount] = revChunkPlace;
				revListCount--;
			}

			for(int r = 1; r < rowHalf; r++)
			{


				for (int c = 0; c < column; c++)
				{
					listCount++;
					revChunkPick = chunkList[revListCount];
					revPlacement = revChunkPick.transform.position;
					revPlacement.x = (((midNum - revPlacement.x)*2)+revPlacement.x);
					revPlacement.z = (((midNum - revPlacement.z)*2)+revPlacement.z);
					//Vector3 revPlaceRot = (revChunkPick.transform.localRotation.eulerAngles.y + 180);
					revChunkPlace = Instantiate(revChunkPick,revPlacement,Quaternion.Euler(revChunkPick.transform.rotation.eulerAngles)) as GameObject;
					revChunkPlace.name = "Chunk "+(r+(midNum/10))+", "+c;
					revChunkPlace.transform.parent = this.transform;
					chunkList[listCount] = revChunkPlace;
					revListCount--;
				}
			}
			Vector3 redBasePos = new Vector3(midNum,0,(chunkList[0].transform.position.z)-10); 
			Vector3 bluBasePos = new Vector3(midNum,0,(row*10));

			Instantiate(redSpawn,redBasePos,Quaternion.Euler(transform.rotation.eulerAngles));
			Instantiate(blueSpawn,bluBasePos,Quaternion.Euler(transform.rotation.eulerAngles));

			Vector3 redColPos = new Vector3(midNum+10,0,(chunkList[0].transform.position.z)-10); 
			Vector3 bluColPos = new Vector3(midNum-10,0,(row*10));
			Instantiate(redCollection,redColPos,Quaternion.Euler(transform.rotation.eulerAngles));
			Instantiate(blueCollection,bluColPos,Quaternion.Euler(transform.rotation.eulerAngles));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
