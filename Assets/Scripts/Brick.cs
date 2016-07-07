using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	public Sprite[] healthSprites;
	public static int brickCount = 0;
	public AudioClip breakSound;
	public AudioClip weakSound;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			brickCount++;
		}

		timesHit = 0;
		LoadSprites ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHit++;
		if (Health() < 1) {
			brickCount--;
			levelManager.BrickDestroyed ();
			AudioSource.PlayClipAtPoint (breakSound, transform.position);
			Destroy (gameObject);
		} else {
			AudioSource.PlayClipAtPoint (weakSound, transform.position);
			LoadSprites ();
		}
	}

	int Health() {
		return maxHits - timesHit;
	}

	public void LoadSprites() {
		int spriteIndex = Health () - 1;
		if (healthSprites[spriteIndex]) {
			GetComponent<SpriteRenderer> ().sprite = healthSprites[spriteIndex];
		}

	}
		
}
