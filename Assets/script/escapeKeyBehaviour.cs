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

	public string menuSceneName;
	private bool quitKey;

	// Use this for initialization
	void Start () {
		quitKey = false;
	}
	// Update is called once per frame
	void Update () {

		quitKey = Input.GetKeyDown("escape");

		if(quitKey){
			this.loadSceneMenu();
		}
	}
	void loadSceneMenu() {
		Debug.Log("Loading scene : " + menuSceneName);
		Application.LoadLevel(menuSceneName);
	}
	void quit() {
		Debug.Log("Quitting...");
		Application.Quit();
	}
}
