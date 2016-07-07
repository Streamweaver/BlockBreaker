using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	void Awake() {
		Brick[] bricks = GameObject.FindObjectsOfType<Brick> ();
		for (int i = 0; i < bricks.Length; i++) {
			bricks [i].maxHits = RandHits ();
			bricks [i].LoadSprites ();
		}
	}

	private int RandHits() {
		int health;
		int lvlIdx = SceneManager.GetActiveScene ().buildIndex;
		int rnd = Random.Range (0, 80) + lvlIdx * 15;
		if (rnd > 100) {
			health = 3;
		} else if (rnd > 80) {
			health = 2;
		} else {
			health = 1;
		}
		return health;
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void BrickDestroyed() {
		if (Brick.brickCount <= 0) {
			LoadNextLevel ();
		}
	}
}
