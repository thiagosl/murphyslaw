using UnityEngine;
using System.Collections;

public class DiscoScript : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;

	private Rigidbody2D rb;
	private ScoreManager scoreManager;

	void Start()
	{
		this.horizontalSpeed = -14f;
		this.verticalSpeed = 0;
		this.rb = GetComponent<Rigidbody2D>();
		this.scoreManager = GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreManager>();
	}

	void FixedUpdate()
	{
		Move ();
	}

	void UpdateScore() {
		scoreManager.IncrementScore (50);
	}

	private void Move ()
	{
		rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name.Equals ("ScreenLimit")) {
			Destroy (gameObject);
		}
		if (other.tag.Equals ("Player")) {
			var audioSource = GetComponent<AudioSource> ();
			audioSource.Play ();
			UpdateScore ();
			Destroy (gameObject);
		}
	}
}
