/*!
 * \file levelBehaviour.cs
 * \brief Script de contrôle du level
 * \date 21.08.2015
 * \version 0.1
 * \author Jérémy Jayet
 */﻿

using UnityEngine;
using System.Collections;

public class levelBehaviour : MonoBehaviour {

	private Animator thisAnimator;

	public float fadeOutAnimTime;
	public string menuSceneName;

	void Start() {
		//GameObject.FindWithTag("Player").SendMessage("setLevelObj", this.gameObject);
		thisAnimator = this.GetComponent<Animator>();
	}

	void Update() {}

	IEnumerator goToMainMenu() {
		Debug.Log("Loading scene : " + menuSceneName);
		thisAnimator.SetTrigger("fadeOut");
		PlayerPrefs.SetInt("deathCounter", 0);
		yield return new WaitForSeconds(fadeOutAnimTime);
		PlayerPrefs.Save();
		Application.LoadLevel(menuSceneName);
	}

	IEnumerator reloadLevel() {
		Debug.Log("Loading scene : " + Application.loadedLevel);
		thisAnimator.SetTrigger("fadeOut");
		yield return new WaitForSeconds(fadeOutAnimTime);
		Application.LoadLevel(Application.loadedLevel);
	}
}
