using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		Destroy(this.gameObject,particleSystem.duration+0.5f);
	
	}
}
