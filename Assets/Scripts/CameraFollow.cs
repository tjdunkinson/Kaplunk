using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public int playerNum;
	public Transform player;
	public float Distance;
	public float lerpSpeed;

	private Vector3 finalPos;
	private TextMesh resourceCount;
	private player plyr;

	// Use this for initialization
	void Start () 
	{
		resourceCount = GetComponentInChildren<TextMesh> ();
		plyr = player.GetComponent<player> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {

		/*if (player == null)
		{
			player = GameObject.Find("Player0"+playerNum).transform;
			plyr = player.GetComponent<player> ();
		}*/
		finalPos = player.position;
		finalPos.y = finalPos.y + Distance;
		transform.position = Vector3.Lerp(transform.position,finalPos,Time.deltaTime*lerpSpeed);

		resourceCount.text = plyr.resource.ToString ();

	}
}
