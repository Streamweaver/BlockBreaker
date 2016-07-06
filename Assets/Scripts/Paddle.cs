using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private Vector3 paddlePos;

	// Use this for initialization
	void Start () {
		paddlePos = new Vector3 (8f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);

		this.transform.position = paddlePos;
	}
}
