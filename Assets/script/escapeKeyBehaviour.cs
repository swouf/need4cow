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
	private GameObject	levelObj = null;

	// Use this for initialization
	void Start () {
		quitKey = false;

		levelObj = GameObject.Find("FaderLayer");
		if(levelObj == null) {
			Debug.LogWarning("Impossible de récupérer l'objet FaderLayer !");
		}
	}
	// Update is called once per frame
	void Update () {
		quitKey = Input.GetKeyDown("escape");

		if(quitKey){
			levelObj.SendMessage("goToMainMenu");
		}
		/*** ! CODE NON FONCTIONNEL !								***
		 *** Censé permettre de quitter en pressant escape depuis	***
		 *** le menu principal										***
		else if(Application.loadedLevel == levelObj.menuSceneName) {
			Application.Quit();
		}
		***/
	}
	void quit() {
		Debug.Log("Quitting...");
		Application.Quit();
	}
}
