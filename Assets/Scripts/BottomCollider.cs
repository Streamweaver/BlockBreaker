using UnityEngine;
using System.Collections;

public class BottomCollider : MonoBehaviour {

	public LevelManager levelManager;
		
	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Triggered by" + collider);
		levelManager.LoadLevel ("Win");
	}
		
}
