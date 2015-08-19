/*!
 * \file playerBehaviour.cs
 * \brief Script de contrôle du joueur
 * \date 21.08.2015
 * \version 0.1
 * \author Jérémy Jayet
 */
using UnityEngine;
using System.Collections;

public class playerBehaviour : MonoBehaviour {

	private bool		jumpKey;
	private Rigidbody2D	thisRB;
	private bool		isOnGround;
	private bool		isDead;
	// sons
	private AudioSource source;
	// camera
	private GameObject	mainCamera;
	private Camera		mainCamComp;
	// animation
	private Animator	thisAnim;
	// Player dans la caméra gestion
	float minPosX = 0;
	float camPosX = 0;
	float offsetPlayerX = 0;

	/*!
	 * \brief Vitesse du personnage en px/s
	 */
	public float speed;
	public float jumpForce;
	public float playerHeight;
	public float dyingTorqueIntensity;
	public float timeBeforeReboot;

	// Use this for initialization
	void Start () {
		Debug.Log("Player initialised.");
		jumpKey	= false;
		isDead	= false;
		if(timeBeforeReboot <= 0.0) {
			timeBeforeReboot = 1.0f;
		}
		thisAnim = GetComponent<Animator>();
		if(thisAnim == null) {
			Debug.LogWarning("Impossible de récupérer l'animation du joueur");
		}

		thisRB = GetComponent<Rigidbody2D>();

		source = this.GetComponent<AudioSource>();

		mainCamera = GameObject.FindWithTag("MainCamera");
		if(mainCamera == null) {
			Debug.LogWarning("Player : Impossible de récupérer la caméra principale.");
		}
		else {
			mainCamComp = mainCamera.GetComponent<Camera>();
			if(mainCamComp == null) {
				Debug.LogWarning("Player : Impossible de récupérer la composante caméra de la cam principale");
			}
		}


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

		if(isDead) {
			timeBeforeReboot -= Time.deltaTime;
		}
		if(timeBeforeReboot <= 0.0){
			Application.LoadLevel(Application.loadedLevel);
		}

		// Checking de la position
		camPosX = mainCamera.transform.position.x;
		offsetPlayerX = mainCamComp.orthographicSize * mainCamComp.aspect;
		minPosX = camPosX - offsetPlayerX;

		if(transform.position.x <= minPosX) {
			this.die();
		}
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
		BoxCollider2D thisCollider = GetComponent<BoxCollider2D>();
		isDead = true;

		Debug.Log("The Player is Dead !!!");
		isOnGround = true;
		jump();
		isOnGround = false;

		source.PlayOneShot(source.clip);

		thisCollider.enabled = false;
		thisRB.freezeRotation = false;
		thisRB.AddTorque(dyingTorqueIntensity, ForceMode2D.Impulse);

		// Unsync Camera
		mainCamera.SendMessage("setVerticalSyncWithPlayer", false);
		mainCamera.SendMessage("stop");
		this.stop();
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
		// Debug.Log("Playeur : Je ne touche plus le sol.");
		isOnGround = false;
	}
	void stop() {
		thisAnim.enabled = false;
		speed = 0.0f;
	}
}
