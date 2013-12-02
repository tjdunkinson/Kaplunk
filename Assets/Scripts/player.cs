using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public float speed;
	public float playerRotSpeed;
	public int playerNum;
	public int Health = 5;
	public GameObject bomb;
	public float slowDown = 2f;
	public string team;
	public GameObject myLamp;

	//public Vector3 vel;
	//public float vel2;

	private float destroyDelay;
	private Vector3 movement;
	private GameObject myRespawner;
	private bool hor,ver;
	private LayerMask la;
	private CharacterController charCont;


	
	// Use this for initialization
	void Awake () {
		myRespawner = GameObject.Find("Player0"+playerNum+"Respawner");
		Respawner r = myRespawner.GetComponent<Respawner>();
		destroyDelay = (r.setTimer + (r.deathCount*r.penalty))-0.01f;
		gameObject.name = "Player0"+playerNum;
		charCont = GetComponent<CharacterController>();

		la = LayerMask.NameToLayer(team);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal0"+playerNum) != 0)
		{hor = true;}
		else
		{hor = false;}
		if (Input.GetAxis("Vertical0"+playerNum) != 0)
		{ver = true;}
		else
		{ver = false;}

		if(hor || ver)
		{
			//movement = transform.position;
			movement.x = Input.GetAxis("Horizontal0"+playerNum)*speed;
			movement.z = Input.GetAxis("Vertical0"+playerNum)*speed;
			//transform.position = movement;
			charCont.Move(movement);
			if (movement.magnitude > speed)
			{
				movement = movement.normalized*speed;
			}
		}

		if (movement.magnitude > 0.01)
		{
			Quaternion rot = Quaternion.LookRotation(movement);
			transform.rotation = Quaternion.Slerp(transform.rotation,rot,Time.deltaTime*playerRotSpeed);
		}

		if (Input.GetButtonDown("PlaceBomb0"+playerNum))
		{
			RaycastHit hit;
			Physics.Raycast(this.transform.position,-transform.up,out hit,1f);
			
			GameObject bombPlace;
			bombPlace = Instantiate(bomb,hit.collider.gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
		}
		if (Input.GetButtonDown("EnableLight0"+playerNum))
		{
			myLamp.SetActive(!myLamp.activeSelf);
		}
	

	}
	void Death ()
	{
		//rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		myRespawner.SendMessage("startRespawn");
		Destroy(this.gameObject,destroyDelay);
	}
	
}
