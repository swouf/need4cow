using UnityEngine;
using System.Collections;

public class worldSwitch : MonoBehaviour {
	public bool isRedActive;
	public bool isBlueActive;
	// Use this for initialization
	void Start () {
		if(isRedActive) {
			isBlueActive = false;
		}
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("s")) {
			Debug.Log("Switching !");
			switchWorld();
		}
	}
	void switchWorld() {
		if(isRedActive) {
			GameObjects[] toActivateList = FindGameObjectsWithTag("red");
			GameObjects[] toDeactivateList = FindGameObjectsWithTag("blue");
		}

		foreach(GameObject element in toActivateList) {
			element.SetActive(true);
		}
		foreach(GameObject element in toDeactivateList) {
			element.SetActive(false);
		}
	}
}
