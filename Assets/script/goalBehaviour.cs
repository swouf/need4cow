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
	private Collider2D thisCollider = null;
	private GameObject	mainCamera = null;
	private GameObject	levelObj = null;

	//public string		winScreen; // À décommenté pour activer le winScreen

	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<BoxCollider2D>();
		if(thisCollider == null) {
			Debug.LogWarning(this.ToString() + " : Impossible de récupérer le collider.");
		}
		mainCamera = GameObject.FindWithTag("MainCamera");
		if(mainCamera == null) {
			Debug.LogWarning(this.ToString() + " : Impossible de récupérer la mainCamera.");
		}
		levelObj = GameObject.Find("FaderLayer");
		if(levelObj == null) {
			Debug.LogWarning("Impossible de récupérer l'objet FaderLayer !");
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D Collision) {
		if(Collision.gameObject.tag == "Player") {
			Collision.gameObject.SendMessage("stop");
			mainCamera.SendMessage("stop");
			levelObj.SendMessage("goToMainMenu");
			//Application.LoadLevel(winScreen); // À décommenter pour activer le winScreen
		}
	}
}
