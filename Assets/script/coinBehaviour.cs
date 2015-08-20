using UnityEngine;
using System.Collections;
using System;

public class coinBehaviour : MonoBehaviour {
	private bool		hasBeenTouched;
	private Collider2D	thisCollider;
	private float		posX;
	private float		posY;
	private float		timeElapsed;
	private float		normalizedTime;

	private AudioSource source;

	public float		animTime;
	public float		animHeight;

	// Use this for initialization
	void Start () {

		source = this.GetComponent<AudioSource>();

		hasBeenTouched = false;
		thisCollider = GetComponent<Collider2D>();
		if(thisCollider.isTrigger == false) {
			Debug.LogWarning("The coin " + ToString() + "was not set as a trigger !");
			thisCollider.isTrigger = true;
		}
		posX = transform.position.x;
		posY = transform.position.y;
	}

	// Update is called once per frame
	void Update() {
		if(hasBeenTouched) {
			timeElapsed += Time.deltaTime;
			normalizedTime = timeElapsed / animTime;
			posY += (float)Math.Sin(normalizedTime * Math.PI * 2) * animHeight;

			transform.position = new Vector2(posX, posY);
			if(timeElapsed >= animTime) {
				Destroy(this.gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
			Debug.Log("Le player à touché la pièce : " + ToString());

			source.PlayOneShot(source.clip);

			if(hasBeenTouched == false) {
				collider.gameObject.SendMessage("addCoins", 1);
			}
			hasBeenTouched = true;
		}
    }
}
