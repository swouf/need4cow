/*!
 * \file spikesBehaviour.cs
 * \brief Script de contrôle des piques et autres ennemies immobiles
 * \date 21.08.2015
 * \version 0.1
 * \author Jérémy Jayet
 */﻿

using UnityEngine;
using System.Collections;

public class spikesBehaviour : MonoBehaviour {

	private Collider2D thisCollider;
	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<Collider2D>();
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
