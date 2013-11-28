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
			//rigidbody.AddForce((Input.GetAxis("Horizontal0"+playerNum))*speed,0,0);
			movement.x = Input.GetAxis("Horizontal0"+playerNum)*speed;
		}
		if (Input.GetAxis("Vertical0"+playerNum) != 0)
		{
			//rigidbody.AddForce(0,0,-(Input.GetAxis("Vertical0"+playerNum)*speed));
			movement.z = Input.GetAxis("Vertical0"+playerNum)*speed;
		}

		movement = movement.normalized;
		rigidbody.AddForce(movement);

		Vector3 current = rigidbody.velocity;
		Quaternion rot = Quaternion.LookRotation(current);
		transform.rotation = Quaternion.Slerp(transform.rotation,rot,Time.deltaTime*playerRotSpeed);



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
