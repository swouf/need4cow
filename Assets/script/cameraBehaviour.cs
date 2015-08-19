using UnityEngine;
using System.Collections;

public class cameraBehaviour : MonoBehaviour {

	private GameObject Player;
	private float camZ;

	public float speed;
	public float horizontalOffsetToPlayer;
	public float verticalOffsetToPlayer;
	public bool verticalSyncWithPlayer;
	// Use this for initialization

	void Start () {
		camZ = transform.position.z;
		Player = GameObject.FindWithTag("Player");
		if(Player == null) {
			Debug.Log("cameraBehaviour : Impossible de récupérer le Player.");
		}

		transform.position =
			new Vector3(Player.transform.position.x + horizontalOffsetToPlayer,
						Player.transform.position.y + verticalOffsetToPlayer,
						camZ);
	}

	// Update is called once per frame
	void Update () {
		float dt		= Time.deltaTime;
		float dx		= dt*speed;
		float camY		= 0;

		float camX = transform.position.x + dx;

		if(verticalSyncWithPlayer) {
			camY = Player.transform.position.y + verticalOffsetToPlayer;
		}
		else {
			camY = transform.position.y;
		}
		transform.position = new Vector3(camX, camY, camZ);
	}

	void setVerticalSyncWithPlayer(bool isSync) {
		verticalSyncWithPlayer = isSync;
	}
}
