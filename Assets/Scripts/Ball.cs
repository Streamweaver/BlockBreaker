using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private AudioSource audio;
	private Vector3 paddleToBallVector;
	private bool launched;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		launched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!launched) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0)) {
				launched = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 8f) ;
			}
		}

	}

	void OnCollisionEnter2D (Collision2D col) {
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if (launched) {
			this.GetComponent<Rigidbody2D> ().velocity += tweak;
			audio.Play ();	
		}
	}
}
