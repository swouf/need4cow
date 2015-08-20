using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class coinCounterBehaviour : MonoBehaviour {
	private Text thisTxt = null;
	private int coins = 0;

	public int coinsAtBeginning;

	// Use this for initialization
	void Start () {
		thisTxt = GetComponent<Text>();
		coins += coinsAtBeginning;
	}

	// Update is called once per frame
	void Update () {}

	void setValue(int val) {
		coins = val;
		thisTxt.text = coins + " x";
		if(coins > PlayerPrefs.GetInt("coinsHighScore" + Application.loadedLevel)) {
			PlayerPrefs.SetInt("coinsHighScore" + Application.loadedLevel, coins);
			PlayerPrefs.Save();
		}
	}
}
