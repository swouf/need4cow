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

	private float		jump;
	private float		switchWorld;
	private double		dx;
	private Rigidbody	thisRB;
	private bool		isOnGround;

	/*!
	 * \brief Vitesse du personnage en px/s
	 */
	public double speed;

	// Use this for initialization
	void Start () {
		Debug.log("Player initialised.");

		jump			= 0;
		switchWorld		= 0;
		dx				= 0;

		thisRB = GetComponent<Rigidbody>();
		thisRB.velocity = new Vector2(speed, 0);
	}

	/*!
	 * \brief Update is called once per frame
	 */
	void Update () {
		jump = Input.GetAxis("Fire1");
		switchWorld = Input.GetAxis("Fire2");

		if(jump > 0.0) {
			this.jump();
		}
		if(switchWorld > 0.0) {
			Debug.Log("Switching !");
		}
	}

	/*!
	 * \brief Fonction de saut (fait sauter le joueur)
	 */
	void jump() {
		Debug.Log("Jump !");
	}
}
