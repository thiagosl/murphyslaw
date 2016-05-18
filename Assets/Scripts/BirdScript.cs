using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;

	private Rigidbody2D rb;
	private Transform tf;
	private Animator animator;
	void Start()
	{
		this.horizontalSpeed = -12f;
		this.verticalSpeed = -18f;
		this.rb = GetComponent<Rigidbody2D>();
		this.tf = GetComponent<Transform> ();
		this.animator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		Move();
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
		this.verticalSpeed *= -1;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
