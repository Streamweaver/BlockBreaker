using UnityEngine;
using System.Collections;

public class BottomCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		levelManager.LoadLevel ("Lose");
	}
		
}
