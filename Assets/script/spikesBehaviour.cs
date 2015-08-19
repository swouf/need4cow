using UnityEngine;
using System.Collections;

public class spikesBehaviour : MonoBehaviour {

	private Collider2D thisCollider;
	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<BoxCollider2D>();
		if(thisCollider == null)
		{
			Debug.LogWarning(this.ToString() + " : Impossible de récupérer le collider.");
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D Collision) {
		if(Collision.gameObject.tag == "Player") {
			Collision.gameObject.SendMessage("die");
		}
	}
}
