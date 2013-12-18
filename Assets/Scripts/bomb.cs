using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {
	
	
	public float timer;
	public float setRadius;
	public GameObject explosion;

	private MeshRenderer rend;
	// Use this for initialization
	void OnDrawGizmosSelected () {
		Gizmos.DrawWireSphere(this.transform.position,setRadius);
	}
	void Start()
	{
		rend = GetComponent<MeshRenderer>();
	}
	void Update ()
	{
		timer -= Time.deltaTime;
		
		if (timer <= 0f)
		{
			Explode();
		}
	}
	void Explode() {
		Collider[] hitObjects = Physics.OverlapSphere(this.transform.position, setRadius);
		SendMessageOptions options;
		options = SendMessageOptions.DontRequireReceiver;
		int i =0;
		while(i < hitObjects.Length)
		{
			//print (hitObjects[i].name);
			if (hitObjects[i].tag == "Wall")
			{
				hitObjects[i].SendMessage("Destroy",options);
			}
			if (hitObjects[i].tag == "Player")
			{
				hitObjects[i].SendMessage("Death",options);
			}
			//Blackens Radius
			if (hitObjects[i].tag == "Ground")
			{
				Vector3 pos = hitObjects[i].transform.position;
				pos.y += 0.1f;
				Instantiate(explosion,pos,Quaternion.Euler(Vector3.up));
			}
			i++;
			rend.enabled = false;
		}
		if (i == hitObjects.Length)
		{
			//Instantiate(explosion,transform.position,Quaternion.Euler(Vector3.up));
			Destroy (this.gameObject);
		}
    }
}
