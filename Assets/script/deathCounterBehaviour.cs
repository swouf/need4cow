using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class deathCounterBehaviour : MonoBehaviour {
	private Text thisTxt = null;
	private int deaths = 0;

	// Use this for initialization
	void Start () {
		thisTxt = GetComponent<Text>();
		deaths = PlayerPrefs.GetInt("deathCounter", 0);
		refresh();
	}

	// Update is called once per frame
	void Update () {}

	void addDeath() {
		deaths++;
		refresh();
		if(deaths > PlayerPrefs.GetInt("deathsHighScore" + Application.loadedLevel)) {
			PlayerPrefs.SetInt("deathsHighScore" + Application.loadedLevel, deaths);
		}
		PlayerPrefs.SetInt("deathCounter", deaths);
		PlayerPrefs.Save();
	}
	void refresh() {
		thisTxt.text = deaths + " x";
	}
}
