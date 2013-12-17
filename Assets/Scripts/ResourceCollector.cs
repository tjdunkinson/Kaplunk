using UnityEngine;
using System.Collections;

public class ResourceCollector : MonoBehaviour {

	public int resource;
	public LayerMask enemy,friendly;
	//private int myTeam,myEnemy;

	private TextMesh textCount;

	// Use this for initialization
	void Start () {
		textCount = GetComponentInChildren<TextMesh> ();
	
	}
	
	// Update is called once per frame
	void Hurt (GameObject miner) 
	{
		player give = miner.GetComponent<player>();
		if (give.originTeam == enemy)
		{
			if (resource > 0)
			{
				miner.SendMessage ("Collect", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	void OnTriggerEnter (Collider col)
	{
		player get = col.GetComponent<player>();
		if (get.originTeam == friendly)
		{
			resource += get.resource;
			get.resource = 0;
		}
	}
	void Update ()
	{
		textCount.text = resource.ToString ();	
	}
}
