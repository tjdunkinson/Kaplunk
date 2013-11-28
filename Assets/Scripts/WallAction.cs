using UnityEngine;
using System.Collections;

public class WallAction : MonoBehaviour {
	
	public int Health = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Health <= 0)
		{
			Destroy();
		}
		
	}
	void Destroy ()
	{
		Destroy (this.gameObject);
	}
	void OnMouseDown()
	{
		Health--;
	}
}
