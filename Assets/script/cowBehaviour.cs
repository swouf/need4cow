using UnityEngine;
using System.Collections;

public class cowBehaviour : MonoBehaviour {

	private Rigidbody2D	thisRB;

	/*!
	 * \brief Vitesse de la vache en px/s
	 */
	public float speed;

	// Use this for initialization
	void Start () {
		Debug.Log("Cow initialised.");

		thisRB = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		float velY = thisRB.velocity.y;
		thisRB.velocity = new Vector2(speed, 0);
	}
}
