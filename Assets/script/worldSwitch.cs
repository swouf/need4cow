using UnityEngine;
using System.Collections;

public class worldSwitch : MonoBehaviour {
	public bool isRedActive;
	// Use this for initialization
	void Start () {
		Debug.Log("worldSwitch Initialization...");
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("s")) {
			Debug.Log("Switching !");
			this.switchWorld();
		}
	}
	void switchWorld() {
		if(isRedActive) {
			GameObject[] toActivateList = FindGameObjectsWithTag("blue");
			GameObject[] toDeactivateList = FindGameObjectsWithTag("red");
			isRedActive = false;
		}
		else {
			GameObject[] toActivateList = FindGameObjectsWithTag("red");
			GameObject[] toDeactivateList = FindGameObjectsWithTag("blue");
			isRedActive = true;
		}

		foreach(GameObject element in toActivateList) {
			element.SetActive(true);
		}
		foreach(GameObject element in toDeactivateList) {
			element.SetActive(false);
		}
	}
}
