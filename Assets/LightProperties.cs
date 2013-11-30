using UnityEngine;
using System.Collections;

public class LightProperties : MonoBehaviour {

	private Vector4 update,set;

	// Use this for initialization
	void Start () {
	
		set = renderer.material.GetVector("_Color");
	}
	
	// Update is called once per frame
	void Illuminate (float shadow) 
	{
		update = set;
		update.w = shadow;
		renderer.material.SetVector("_Color",update);
	}
	void ResetLight ()
	{
		renderer.material.SetVector("_Color",set);
	}
}
