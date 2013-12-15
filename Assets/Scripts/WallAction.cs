using UnityEngine;
using System.Collections;

public class WallAction : MonoBehaviour {
	
	public int Health = 3;

	// Use this for initialization
	void Start () {
		renderer.material.SetTextureOffset("_MainTex",new Vector2(0,0.5f));
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Health == 2)
		{
			renderer.material.SetTextureOffset("_MainTex",new Vector2(0.5f,0.5f));

		}
		if (Health == 1)
		{
			renderer.material.SetTextureOffset("_MainTex",new Vector2(0f,0f));
		}
		if (Health <= 0)
		{
			Destroy();
		}
		
	}
	void Destroy ()
	{
		Destroy (this.gameObject);
	}    
	void Hurt()
	{
		Health--;
	}
}
