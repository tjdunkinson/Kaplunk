using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject playerBase, playerCamBase;
	public int myPlayerNum;
	public string Mutual, Team;
	public Color lit, unlit;

	public float setTimer = 5f;
	public float penalty = 0.5f;
	public int deathCount;
	 
	public GameObject myPlayer;
	public GameObject myPlayerCam;
	private bool startTimer = false;
	private float timer;
	// Use this for initialization
	void Awake () {
		timer = setTimer;

		myPlayer = playerBase;
		myPlayer.name = "Player0" + myPlayerNum;
		player myPlayerScript = myPlayer.GetComponent<player> ();
		myPlayerScript.playerNum = myPlayerNum;
		myPlayerScript.originTeam = LayerMask.NameToLayer (Team);
		myPlayerScript.myTeam = Team;
		myPlayerScript.mutual = Mutual;
		myPlayerScript.visable = lit;
		myPlayerScript.invisible = unlit;
		myPlayerScript.myRespawner = this.gameObject;
		myPlayerScript.enabled = true;

		myPlayerCam = playerCamBase;
		myPlayerCam.name = "PlayerCam0" + myPlayerNum;
		CameraFollow myPlyrCamScript = myPlayerCam.GetComponent<CameraFollow> ();
		myPlyrCamScript.playerNum = myPlayerNum;

		GameObject spawnPlayer;
		spawnPlayer = Instantiate (myPlayer, transform.position, Quaternion.Euler (myPlayer.transform.rotation.eulerAngles)) as GameObject;
		GameObject spawnCam;
		spawnCam = Instantiate (myPlayerCam) as GameObject;

	
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
		Instantiate(myPlayer,this.transform.position,Quaternion.Euler(myPlayer.transform.rotation.eulerAngles));
		startTimer = false;
		timer = setTimer + (deathCount*penalty);

	}

}
