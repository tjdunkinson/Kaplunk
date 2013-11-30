using UnityEngine;
using System.Collections;

public class light : MonoBehaviour {

	public float setRadius;
	public float setBuffer;

	private float fullRadius;
	
	// Use this for initialization
	void OnDrawGizmosSelected () {
		Gizmos.DrawWireSphere(this.transform.position,setRadius);
		Gizmos.DrawWireSphere(this.transform.position,setRadius + setBuffer);
	}
	void Update ()
	{
		fullRadius = setRadius + setBuffer;

		RaycastHit hit;
		Collider[] litObjects = Physics.OverlapSphere(this.transform.position, fullRadius);
		for(int i = 0; i < litObjects.Length; i++)
		{
			if (Physics.Linecast(this.transform.position,litObjects[i].transform.position,out hit))
			{
				float shadow;
				if (hit.distance < setRadius)
				{
					shadow = Mathf.InverseLerp(setRadius,0,hit.distance);
					litObjects[i].SendMessage("Illuminate",shadow,SendMessageOptions.DontRequireReceiver);
				}
				if (hit.distance >= setRadius)
				{
					litObjects[i].SendMessage("ResetLight",SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
