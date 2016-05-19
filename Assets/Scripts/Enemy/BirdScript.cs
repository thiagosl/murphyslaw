using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;

	private bool scored;
	private ScoreManager scoreManager;
	private Transform playerTransform;
	private Transform tf;
	private Rigidbody2D rb;
	void Start()
	{
		this.scored = false;
		this.horizontalSpeed = -12f;
		this.verticalSpeed = -18f;
		this.rb = GetComponent<Rigidbody2D>();
		this.scoreManager = GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreManager>();
		this.tf = GetComponent<Transform> ();
		this.playerTransform = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}

	void FixedUpdate()
	{
		Move();
		UpdateScore ();
	}

	void UpdateScore() {
		if (tf.position.x < playerTransform.position.x && !scored) {
			scoreManager.IncrementScore (10);
			this.scored = true;
		}
	}

	private void Move ()
	{
		rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name.Equals ("ScreenLimit"))
		{
			Destroy (gameObject);
		}
		if (!other.tag.Equals ("Powerup") && !other.tag.Equals ("Enemy")) {
			this.verticalSpeed *= -1;
		}
		//print ("colidiu com "+other.name+"x1 = "+other.transform.position.x+" y1 = "+other.transform.position.y+" z1 = "+other.transform.position.z+" x2 = "+tf.position.x+" y2 = "+tf.position.y+" z2 = "+tf.position.z);
	}
}
