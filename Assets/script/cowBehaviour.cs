/*!
 * \file cowBehaviour.cs
 * \brief Script de contrôle de la vache
 * \date 21.08.2015
 * \version 0.1
 * \author Jérémy Jayet
 */﻿

using UnityEngine;
using System.Collections;

public class cowBehaviour : MonoBehaviour {

	private AudioSource source;
	private Rigidbody2D	thisRB;

	/*!
	 * \brief Vitesse de la vache en px/s
	 */
	public float speed;

	// Use this for initialization
	void Start () {
		Debug.Log("Cow initialised.");

		source = this.GetComponent<AudioSource>();
		source.PlayOneShot(source.clip);
		thisRB = GetComponent<Rigidbody2D>();
		thisRB.gravityScale = 0.0f;
	}

	// Update is called once per frame
	void Update () {

		float velY = thisRB.velocity.y;
		/** Si la vache tombe, supprimez la ligne 1, et décommentez
		 *  la ligne 2. **/
		thisRB.velocity = new Vector2(speed, velY); // LIGNE 1
		// thisRB.velocity = new Vector2(speed, 0); // LIGNE 2
	}
}
