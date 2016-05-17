using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;

	private Rigidbody2D rb;
	void Start()
	{
		this.horizontalSpeed = -5f;
		this.verticalSpeed = -10f;
		this.rb = GetComponent<Rigidbody2D>();
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
		this.verticalSpeed *= -1;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
