using UnityEngine;
using System.Collections;

public class worldSwitch : MonoBehaviour {

	private GameObject[] redList;
	private GameObject[] blueList;
	public bool isRedActive;
	// Use this for initialization
	void Start () {
		Debug.Log("worldSwitch Initialization...");

		blueList	= GameObject.FindGameObjectsWithTag("blue");
		redList		= GameObject.FindGameObjectsWithTag("red");
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
		if(isRedActive) {
			isRedActive = false;
		}
		else {
			isRedActive = true;
		}
		foreach(GameObject element in blueList) {
			//Debug.Log(element.ToString());
			element.SetActive(!isRedActive);
		}
		foreach(GameObject element in redList) {
			//Debug.Log(element.ToString());
			element.SetActive(isRedActive);
		}
	}
}
