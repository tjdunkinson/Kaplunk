﻿using UnityEngine;
using System.Collections;

public class ResourceGiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Hurt (GameObject miner)
	{
		miner.SendMessage ("Collect", SendMessageOptions.DontRequireReceiver);

	}
}
