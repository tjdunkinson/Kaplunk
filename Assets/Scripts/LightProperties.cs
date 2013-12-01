using UnityEngine;
using System.Collections;

public class LightProperties : MonoBehaviour {

	private Vector4 update,set;
	public bool lit = false;
	private float shadowValue;

	// Use this for initialization
	void Start () {
	
		set = renderer.material.GetVector("_Color");
	}
	
	void LateUpdate ()
	{
		if (lit)
		{
			update = set;
			update.w = shadowValue;
			renderer.material.SetVector("_Color",update);
		}
		else 
		{
			renderer.material.SetVector("_Color",set);
		}
	}
	void Illuminate (float shadow) 
	{
		lit = true;
		shadowValue = shadow;
	}
	void ResetLight ()
	{
		lit = false;
	}
}
