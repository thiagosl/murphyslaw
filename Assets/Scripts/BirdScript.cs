using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;

	private Rigidbody2D rb;
	//private Animator birdAnimator;

	// Use this for initialization
	void Start()
	{
		this.horizontalSpeed = -5f;
		this.verticalSpeed = -10f;
		this.rb = GetComponent<Rigidbody2D>();
		//this.birdAnimator = GetComponent<Animator>();
		//this.birdAnimator.SetBool("Walking", false);
		//this.birdAnimator.SetBool("Jumping", false);
	}

	void FixedUpdate()
	{
		Move();
		//Move();
		//Jump();
	}

	private void Move ()
	{
		rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		print("colisao com "+other.name);
		this.verticalSpeed *= -1;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
