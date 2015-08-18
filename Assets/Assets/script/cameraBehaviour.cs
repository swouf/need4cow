using UnityEngine;
using System.Collections;

public class cameraBehaviour : MonoBehaviour {

	private GameObject Player;
	private float camZ;

	public float speed;
	public float offsetToPlayer;
	// Use this for initialization

	void Start () {
		camZ = transform.position.z;
		Player = GameObject.FindWithTag("Player");
		if(Player == null) {
			Debug.Log("cameraBehaviour : Impossible de récupérer le Player.");
		}

		transform.position = new Vector3(Player.transform.position.x,
										 Player.transform.position.y,
										camZ);

		float camX = transform.position.x;
		transform.position = new Vector3(camX + offsetToPlayer, camZ);
	}

	// Update is called once per frame
	void Update () {
		float dt		= Time.deltaTime;
		float dx		= dt*speed;

		float camX = transform.position.x;
		float camY = transform.position.y;
		transform.position = new Vector3(camX + dx, camY, camZ);
	}
}
