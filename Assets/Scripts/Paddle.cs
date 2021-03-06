﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Vector3 paddlePos;
	private Ball ball;
	private float xMin = 0.5f;
	private float xMax = 15.5f;

	// Use this for initialization
	void Start () {
		paddlePos = new Vector3 (8f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			MoveWithAutoPlay ();
		}
	}

	void MoveWithMouse() {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, xMin, xMax);
		this.transform.position = paddlePos;
	}

	void MoveWithAutoPlay () {
		ball = GameObject.FindObjectOfType<Ball> ();
		paddlePos.x = Mathf.Clamp (ball.transform.position.x, xMin, xMax);
		this.transform.position = paddlePos;
	}
}
