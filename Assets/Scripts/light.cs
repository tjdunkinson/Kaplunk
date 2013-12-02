using UnityEngine;
using System.Collections;

public class light : MonoBehaviour {

	public float setRadius;

	private float fullRadius;
	public LayerMask layerMask;
	private int la;
	
	// Use this for initialization
	void OnDrawGizmosSelected () {
		Gizmos.DrawWireSphere(this.transform.position,setRadius);
	}
	void Awake ()
	{
		la = ~layerMask;

	}
	void Update ()
	{
		RaycastHit hit;
		Collider[] litObjects = Physics.OverlapSphere(this.transform.position, setRadius);
		for(int i = 0; i < litObjects.Length; i++)
		{
			if (!Physics.Linecast(this.transform.position,litObjects[i].transform.position,out hit,la))
			{
				float dist = Vector3.Distance(transform.position,litObjects[i].transform.position);
				float shadow;
				if (dist <= setRadius)
				{
					shadow = Mathf.InverseLerp(setRadius,0,dist);
					litObjects[i].SendMessage("Illuminate",shadow,SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
