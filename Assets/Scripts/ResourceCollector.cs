using UnityEngine;
using System.Collections;

public class ResourceCollector : MonoBehaviour {

	public int resource;
	public LayerMask enemy,friendly;
	//private int myTeam,myEnemy;

	// Use this for initialization
	void Start () {
		//myEnemy = enemy;
		//myTeam = friendly;
	
	}
	
	// Update is called once per frame
	void Hurt (GameObject miner) 
	{
		player give = miner.GetComponent<player>();
		if (give.originTeam == enemy)
		{
			if (resource > 0)
			{
				give.resource++;
				resource--;
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
}
