/*!
 * \file playerBehaviour.cs
 * \brief Script de contrôle du joueur
 * \date 18.08.2015
 * \version 0.1
 * \author Jérémy Jayet
 */
using UnityEngine;
using System.Collections;

public class playerBehaviour : MonoBehaviour {

	private bool		jumpKey;
	private Rigidbody2D	thisRB;
	private bool		isOnGround;

	/*!
	 * \brief Vitesse du personnage en px/s
	 */
	public float speed;
	public float jumpForce;
	public float playerHeight;

	// Use this for initialization
	void Start () {
		Debug.Log("Player initialised.");

		jumpKey			= false;
		switchWorld		= false;

		thisRB = GetComponent<Rigidbody2D>();
	}

	/*!
	 * \brief Update is called once per frame
	 */
	void Update () {
		jumpKey = Input.GetKeyDown("space");

		if(jumpKey) {
			this.jump();
		}

		float velY = thisRB.velocity.y;
		thisRB.velocity = new Vector2(speed, velY);
	}

	/*!
	 * \brief Fonction de saut (fait sauter le joueur)
	 */
	void jump() {
		if(isOnGround) {
			Debug.Log("Jump !");
			thisRB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
	}
	void die() {
		Debug.Log("The Player is Dead !!!");

	}
	void OnCollisionStay2D(Collision2D collision) {
		//Debug.Log("Ça touche !");
		float maxContactPointY = transform.position.y - (playerHeight/2);
		isOnGround = true;
		foreach(ContactPoint2D contact in collision.contacts) {
			if(contact.point.y >= maxContactPointY) {
				isOnGround = false;
			}
		}
	}
	void OnCollisionExit2D(Collision2D collision) {
		Debug.Log("Playeur : Je ne touche plus le sol.");
		isOnGround = false;
	}
}
