/*!
 * \file escapeKeyBehaviour.cs
 * \brief Script de gestion du menu principal
 * \date 21.08.2015
 * \version 0.1
 * \author Julien Berger qui plagie Jeremsteak
 */

using UnityEngine;
using System.Collections;

public class escapeKeyBehaviour : MonoBehaviour {

	private bool quitKey;

	// Use this for initialization
	void Start () {
		quitKey = false;
	}
	// Update is called once per frame
	void Update () {
		quitKey = Input.GetKeyDown("escape");

		if(quitKey){
			// code pour revenir au menu principal
		}
		/*else if() {
			// code pour quitter le jeu si au menu principal
		}*/
	}
	void quit() {
		Debug.Log("Quitting...");
		Application.Quit();
	}
}
