using UnityEngine;
using System.Collections;

public class mainMenuBehaviour : MonoBehaviour {

	public string tutorialSceneName;
	public string level1SceneName;


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
}
