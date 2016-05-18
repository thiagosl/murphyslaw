using UnityEngine;
using System.Collections;

public class SnakeScript : MonoBehaviour {

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
		this.animator.SetBool ("Walking", true);

		Vector3 scale = tf.localScale;
		scale.x *= -1;
		this.tf.localScale = scale;
	}

	void FixedUpdate()
	{
		Move ();
		Attack ();
	}

	private void Move ()
	{
		rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
	}

	private void Attack()
	{
		Transform playerTransform = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		if (playerTransform.position.x + 12 >= this.tf.position.x) {
			this.animator.SetBool ("Walking", false);
		} else
		{
			this.animator.SetBool ("Walking", true);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name.Equals ("ScreenLimit"))
		{
			Destroy (gameObject);
		}
		print ("colidiu com "+other.name+"x1 = "+other.transform.position.x+" y1 = "+other.transform.position.y+" z1 = "+other.transform.position.z+" x2 = "+tf.position.x+" y2 = "+tf.position.y+" z2 = "+tf.position.z);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
