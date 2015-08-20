/*!
 * \file mainMenuBehaviour.cs
 * \brief Script de gestion du menu principal
 * \date 21.08.2015
 * \version 0.1
 * \author Jérémy Jayet
 */

using UnityEngine;
using System.Collections;

public class mainMenuBehaviour : MonoBehaviour {

	public string tutorialSceneName;
	public string level1SceneName;
	public string level2SceneName;
	public string level3SceneName;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	void loadSceneTutorial() {
		Debug.Log("Loading scene : " + tutorialSceneName);
		Application.LoadLevel(tutorialSceneName);
	}
	void loadSceneLevel1() {
		Debug.Log("Loading scene : " + level1SceneName);
		Application.LoadLevel(level1SceneName);
	}
	void quit() {
		Debug.Log("Quitting...");
		Application.Quit();
	}
}
