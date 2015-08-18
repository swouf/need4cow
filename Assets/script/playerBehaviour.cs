/*!
 * \file playerBehaviour.cs
 * \brief Script de contrôle du joueur
 * \date 18.08.2015
 * \version 0.1
 * \author Jérémy Jayet
 */
using UnityEngine;
using System.Collections;

public class playerBehaviour : MonoBehaviour {

	private float		jumpKey;
	private float		switchWorld;
	private Rigidbody2D	thisRB;
	private bool		isOnGround;

	/*!
	 * \brief Vitesse du personnage en px/s
	 */
	public float speed;

	// Use this for initialization
	void Start () {
		Debug.Log("Player initialised.");

		jumpKey			= 0;
		switchWorld		= 0;

		thisRB = GetComponent<Rigidbody2D>();
	}

	/*!
	 * \brief Update is called once per frame
	 */
	void Update () {
		jumpKey = Input.GetAxis("Fire1");
		switchWorld = Input.GetAxis("Fire2");

		if(jumpKey > 0.0) {
			this.jump();
		}
		if(switchWorld > 0.0) {
			Debug.Log("Switching !");
		}
		thisRB.velocity = new Vector2(speed, 0);
	}

	/*!
	 * \brief Fonction de saut (fait sauter le joueur)
	 */
	void jump() {
		Debug.Log("Jump !");
	}
	void die() {
		Debug.Log("The Player is Dead !!!");
			
	}
}
