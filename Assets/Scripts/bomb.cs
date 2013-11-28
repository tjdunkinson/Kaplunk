using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {
	
	
	public float timer;
	public float setRadius;
	
	// Use this for initialization
	void OnDrawGizmosSelected () {
		Gizmos.DrawWireSphere(this.transform.position,setRadius);
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
			if (hitObjects[i].tag == "Wall")
			{
				hitObjects[i].SendMessage("Destroy",options);
			}
			if (hitObjects[i].tag == "Player")
			{
				hitObjects[i].SendMessage("Death",options);
			}
			//Blackens Radius
			//if (hitObjects[i].tag == "Ground")
			//{
			//	hitObjects[i].renderer.material.color = Color.black;
			//}
			i++;
		}
		if (i == hitObjects.Length)
		{
			Destroy (this.gameObject,0.02f);
		}
    }
}
