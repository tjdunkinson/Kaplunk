using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public float speed;
	public float playerRotSpeed;
	public int playerNum;
	public int Health = 5;
	public int resource;
	public GameObject bomb;
	public string myTeam,mutual;
	public GameObject myLamp;
	public Color visable,invisible;
	public LayerMask originTeam;


	private float destroyDelay;
	private Vector3 movement;
	private GameObject myRespawner;
	private bool hor,ver;
	private LayerMask teamLayer,mutLayer;
	private CharacterController charCont;
	private bool lit,dead = false;
	private bool canAttack;
	private float attackWait = 0.75f;


	
	// Use this for initialization
	void Awake () {
		//Increses respawn time for each death
		myRespawner = GameObject.Find("Player0"+playerNum+"Respawner");
		Respawner r = myRespawner.GetComponent<Respawner>();
		destroyDelay = (r.setTimer + (r.deathCount*r.penalty))-0.01f;
		gameObject.name = "Player0"+playerNum;

		charCont = GetComponent<CharacterController>();

		teamLayer = LayerMask.NameToLayer(myTeam);
		mutLayer = LayerMask.NameToLayer(mutual);

		dead = false;
	}
	void Update () {
		//Disables the player from doing anything when dead
		if (!dead)
		{
			//Checks when movement is being applied
			if (Input.GetAxis("Horizontal0"+playerNum) != 0)
			{hor = true;}
			else
			{hor = false;}
			if (Input.GetAxis("Vertical0"+playerNum) != 0)
			{ver = true;}
			else
			{ver = false;}

			//Applies movement when the above check succeeds
			if(hor || ver)
			{
				//Simple movement application
				movement.x = Input.GetAxis("Horizontal0"+playerNum)*speed;
				movement.z = Input.GetAxis("Vertical0"+playerNum)*speed;
				charCont.Move(movement);
				//Prevents faster movement when going diagonial
				if (movement.magnitude > speed)
				{
					movement = movement.normalized*speed;
				}
			}
			//Makes the player rotate accordingly to move direction
			if (movement.magnitude > 0.01)
			{
				Quaternion rot = Quaternion.LookRotation(movement);
				transform.rotation = Quaternion.Slerp(transform.rotation,rot,Time.deltaTime*playerRotSpeed);
			}

			//Places a bomb
			if (Input.GetButtonDown("PlaceBomb0"+playerNum))
			{
				//Gets the tile below the player
				RaycastHit hit;
				Physics.Raycast(this.transform.position,-transform.up,out hit,1f);
				//Actual placement
				GameObject bombPlace;
				bombPlace = Instantiate(bomb,hit.collider.gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
				//bombPlace.layer = teamLayer.value;
			}
			//Turns light object on and off
			if (Input.GetButtonDown("EnableLight0"+playerNum))
			{
				myLamp.SetActive(!myLamp.activeSelf);
			}

			//Players attck/mining
			if (Input.GetButtonDown("Attack0"+playerNum) && canAttack)
			{
				//Finds object
				RaycastHit swingHit;
				Vector3 fwd = transform.TransformDirection(Vector3.forward);
				if(Physics.Raycast(transform.position,fwd,out swingHit,0.5f))
				{
					//Sends information to object about who is hitting them
					swingHit.collider.SendMessage("Hurt",gameObject,SendMessageOptions.DontRequireReceiver);
				}
				canAttack = false;
			}
			//prevents player from spamming attack
			if (!canAttack)
			{
				attackWait -= Time.deltaTime;
				if (attackWait <= 0)
				{
					canAttack = true;
					attackWait = 0.75f;
				}
			}
			//Kills player
			if (Health <= 0)
			{
				Death();
			}
		}
	}
	void LateUpdate ()
	{
		//Changes visibillity when entering lights
		if (lit)
		{
			gameObject.layer = mutLayer.value;
			renderer.material.color = visable;
		}
		else
		{
			gameObject.layer = teamLayer.value;
			renderer.material.color = invisible;
		}
		lit = false;
	}
	//Death stuff
	void Death ()
	{
		myRespawner.SendMessage("startRespawn");
		Destroy(this.gameObject,destroyDelay);
		dead = true;
	}
	//Being told to light up
	void Illuminate ()
	{
		lit = true;
	}
	//Getting told they are being hit
	void Hurt(GameObject miner)
	{
		Health--;
	}
	
}
