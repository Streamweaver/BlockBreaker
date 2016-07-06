using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;

	private Vector3 paddleToBallVector;

	private bool launched;

	// Use this for initialization
	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;
		launched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!launched) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0)) {
				launched = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 12f) ;
			}
		}

	}
}
