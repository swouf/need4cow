﻿/*!
 * \file playerBehaviour.cs
 * \brief Script de contrôle du joueur
 * \date 18.08.2015
 * \version 0.1
 * \author Jérémy Jayet
 */
using UnityEngine;
using System.Collections;

public class playerBehaviour : MonoBehaviour {

	private bool		jumpKey;
	private bool		switchWorld;
	private Rigidbody2D	thisRB;
	private bool		isOnGround;

	/*!
	 * \brief Vitesse du personnage en px/s
	 */
	public float speed;
	public float playerHeight;

	// Use this for initialization
	void Start () {
		Debug.Log("Player initialised.");

		jumpKey			= false;
		switchWorld		= false;

		thisRB = GetComponent<Rigidbody2D>();
	}

	/*!
	 * \brief Update is called once per frame
	 */
	void Update () {
		jumpKey = Input.GetKeyDown("space");
		switchWorld = Input.GetKeyDown("s");

		if(jumpKey) {
			this.jump();
		}
		if(switchWorld) {
			Debug.Log("Switching !");
		}
		float velY = thisRB.velocity.y;
		//thisRB.velocity = new Vector2(speed, velY);
	}

	/*!
	 * \brief Fonction de saut (fait sauter le joueur)
	 */
	void jump() {
		if(isOnGround) {
			Debug.Log("Jump !");
		}
	}
	void die() {
		Debug.Log("The Player is Dead !!!");

	}
	void OnCollisionStay2D(Collision2D collision) {
		float maxContactPointY = transform.position.y - (playerHeight/2);
		isOnGround = true;
		foreach(ContactPoint2D contact in collision.contacts) {
			if(contact.point.y >= maxContactPointY) {
				isOnGround = false;
			}
		}
	}
	void OnCollistionExit2D(Collision2D collision) {
		isOnGround = false;
	}
}
