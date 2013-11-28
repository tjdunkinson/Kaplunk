using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour {

	public GameObject myPlayer;
	public bool startTimer = false;
	public float setTimer = 5f;
	public float penalty = 0.5f;

	public int deathCount;
	public float timer;
	// Use this for initialization
	void Start () {
		timer = setTimer;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer)
		{
			timer -= Time.deltaTime;
		}
		if (timer <= 0f)
		{
			Respawn();
		}
	
	}
	void startRespawn ()
	{
		startTimer = true;
	}
	void Respawn ()
	{
		deathCount ++;
		startTimer = true;
		Instantiate(myPlayer);
		startTimer = false;
		timer = setTimer + (deathCount*penalty);

	}

}
