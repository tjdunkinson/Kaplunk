using UnityEngine;
using System.Collections;

public class GroundGen : MonoBehaviour {
	
	public int coloumn, row;
	public GameObject tile;
	

	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < row; i++)
		{
			for (int n = 0; n < coloumn; n++)
			{
				GameObject tilePlace;
				Vector3 placement = new Vector3(n,0,i);
				tilePlace = Instantiate(tile,placement,Quaternion.Euler(tile.transform.rotation.eulerAngles)) as GameObject;
				tilePlace.name = "Tile "+i+","+n;
				tilePlace.transform.parent = this.transform;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
