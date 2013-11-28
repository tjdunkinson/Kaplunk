using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public float speed;
	public float playerRotSpeed;
	public int playerNum;
	public int Health = 5;
	public GameObject bomb;
	public GameObject myRespawner;
	public Vector3 vel;
	public float vel2;

	private float destroyDelay;
	private Vector3 movement;
	private bool hor,ver;

	
	// Use this for initialization
	void Awake () {
		myRespawner = GameObject.Find("Player0"+playerNum+"Respawner");
		Respawner r = myRespawner.GetComponent<Respawner>();
		destroyDelay = (r.setTimer + (r.deathCount*r.penalty))-0.01f;

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal0"+playerNum) != 0)
		{
			rigidbody.AddForce((Input.GetAxis("Horizontal0"+playerNum))*speed,0,0);
			hor = true;
		
		}
		else
		{
			hor = false;
		}
		if (Input.GetAxis("Vertical0"+playerNum) != 0)
		{
			rigidbody.AddForce(0,0,-(Input.GetAxis("Vertical0"+playerNum))*speed);
			ver = true;
		}
		else
		{
			ver = false;
		}

		Vector3 current = rigidbody.velocity;
		Quaternion rot = Quaternion.LookRotation(movement);
		transform.rotation = Quaternion.Slerp(transform.rotation,rot,Time.fixedDeltaTime*playerRotSpeed);
		if(hor || ver)
		{
			if (rigidbody.velocity.magnitude >= speed)
			{
				rigidbody.velocity = rigidbody.velocity.normalized*speed;
			}
			rigidbody.drag = 0;
		}
		else
		{
			rigidbody.drag = 2;
		}

		vel2 = rigidbody.velocity.magnitude;
	

	



		if (Input.GetButtonDown("PlaceBomb0"+playerNum))
		{
			RaycastHit hit;
			Physics.Raycast(this.transform.position,-transform.up,out hit,1f);
			
			GameObject bombPlace;
			bombPlace = Instantiate(bomb,hit.collider.gameObject.transform.position,Quaternion.Euler(Vector3.up)) as GameObject;
		}
	

	}
	void Death ()
	{
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		myRespawner.SendMessage("startRespawn");
		Destroy(this.gameObject,destroyDelay);
	}
	
}
