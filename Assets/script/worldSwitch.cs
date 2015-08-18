using UnityEngine;
using System.Collections;

public class worldSwitch : MonoBehaviour {
	public bool isRedActive;
	// Use this for initialization
	void Start () {
		Debug.Log("worldSwitch Initialization...");
		switchWorld();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("s")) {
			Debug.Log("Switching !");
			switchWorld();
		}
	}

	void switchWorld() {
		GameObject[] toActivateList;
		GameObject[] toDeactivateList;
		if(isRedActive) {
			toActivateList =
				GameObject.FindGameObjectsWithTag("blue");
			toDeactivateList =
				GameObject.FindGameObjectsWithTag("red");
			isRedActive = false;
		}
		else {
			toActivateList =
				GameObject.FindGameObjectsWithTag("red");
			toDeactivateList =
				GameObject.FindGameObjectsWithTag("blue");
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
