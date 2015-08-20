/*!
 * \file goalBehaviour.cs
 * \brief Script de contrôle du but des niveaux
 * \date 21.08.2015
 * \version 0.1
 * \author Jérémy Jayet
 */﻿

using UnityEngine;
using System.Collections;

public class goalBehaviour : MonoBehaviour {
	private Collider2D thisCollider;
	private GameObject	mainCamera;

	//public string		winScreen; // À décommenté pour activer le winScreen

	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<BoxCollider2D>();
		if(thisCollider == null) {
			Debug.LogWarning(this.ToString() + " : Impossible de récupérer le collider.");
		}
		mainCamera = GameObject.FindWithTag("MainCamera");
	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D Collision) {
		if(Collision.gameObject.tag == "Player") {
			Collision.gameObject.SendMessage("stop");
			mainCamera.SendMessage("stop");
			//Application.LoadLevel(winScreen); // À décommenté pour activer le winScreen
		}
	}
}
