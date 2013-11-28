﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	public float Distance;
	public float lerpSpeed;

	private Vector3 finalPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		finalPos = player.position;
		finalPos.y = finalPos.y + Distance;

		transform.position = Vector3.Lerp(transform.position,finalPos,Time.deltaTime*lerpSpeed);

	}
}
