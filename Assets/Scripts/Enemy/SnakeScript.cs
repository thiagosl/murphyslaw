using UnityEngine;
using System.Collections;

public class SnakeScript : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;

	private bool scored;
	private Rigidbody2D rb;
	private Transform playerTransform;
	private Transform tf;
	private Animator animator;
	private ScoreManager scoreManager;
	void Start() {
		this.scored = false;
		this.horizontalSpeed = -18f;
		this.verticalSpeed = 0;
		this.rb = GetComponent<Rigidbody2D>();
		this.tf = GetComponent<Transform> ();
		this.playerTransform = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		this.animator = GetComponent<Animator> ();
		this.animator.SetBool ("Walking", true);

		Vector3 scale = tf.localScale;
		scale.x *= -1;
		this.tf.localScale = scale;

		this.scoreManager = GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreManager>();
	}

	void FixedUpdate() {
		Move ();
		Attack ();
		UpdateScore ();
	}

	void UpdateScore() {
		if (tf.position.x < playerTransform.position.x && !scored) {
			scoreManager.IncrementScore (5);
			this.scored = true;
		}
	}

	private void Move () {
		rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
	}

	private void Attack() {
		Transform playerTransform = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		if (playerTransform.position.x + 12 >= this.tf.position.x) {
			this.animator.SetBool ("Walking", false);
		} else
		{
			this.animator.SetBool ("Walking", true);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name.Equals ("ScreenLimit"))
		{
			Destroy (gameObject);
		}
	}
}
