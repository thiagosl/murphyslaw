using UnityEngine;
using System.Collections;

public class DiscoScript : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;

	private Rigidbody2D rb;
	private Transform tf;
	private Animator animator;
	void Start()
	{
		this.horizontalSpeed = -14f;
		this.verticalSpeed = 0;
		this.rb = GetComponent<Rigidbody2D>();
		this.tf = GetComponent<Transform> ();
		this.animator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		Move ();
		Vector3 scale = tf.localScale;
		scale.x *= -1;
		this.tf.localScale = scale;
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
	}

	// Update is called once per frame
	void Update()
	{

	}
}
