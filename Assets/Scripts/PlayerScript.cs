using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool facingRight;
    private Rigidbody2D rb;
    private Transform tf;
    private Animator playerAnimator;

    // Use this for initialization
    void Start()
    {
        this.speed = 5f;
        this.jumpForce = 350f;
        this.facingRight = true;
        this.rb = GetComponent<Rigidbody2D>();
        this.tf = GetComponent<Transform>();
        this.playerAnimator = GetComponent<Animator>();
        this.playerAnimator.SetBool("Walking", false);
        this.playerAnimator.SetBool("Jumping", false);
    }

    void FixedUpdate()
    {
		InfinitRunnerMove ();
        //Move();
        Jump();
    }

	private void InfinitRunnerMove ()
	{
		rb.velocity = new Vector2(speed, rb.velocity.y);
		playerAnimator.SetBool("Walking", true);
	}

    private void Move()
    {
        float horizontalMoviment = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMoviment * speed, rb.velocity.y);
        if (horizontalMoviment < 0 && facingRight)
        {
            this.facingRight = false;
            this.FlipSprite();
        }
        else if (horizontalMoviment > 0 && !facingRight)
        {
            this.facingRight = true;
            this.FlipSprite();
        }
        if (horizontalMoviment != 0)
        {
            playerAnimator.SetBool("Walking", true);
        }
        else
        {
            playerAnimator.SetBool("Walking", false);
        }
    }

    private void FlipSprite()
    {
        Vector3 scale = tf.localScale;
        scale.x *= -1;
        tf.localScale = scale;
    }

    private void Jump()
    {
        bool jumping = Mathf.Abs(rb.velocity.y) > 0.05f;
        if (Input.GetKey("up") && !jumping)
        {
            this.rb.AddForce(new Vector2(0, jumpForce));
            playerAnimator.SetBool("Jumping", true);
			var audioSources = GetComponents<AudioSource> ();
			audioSources[0].Play ();
        }
        if (jumping)
        {
            playerAnimator.SetBool("Jumping", true);
        }
        if (!jumping)
        {
            playerAnimator.SetBool("Jumping", false);
        }
    }

	private void Dead()
	{
		Application.LoadLevel("GameOver");
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(!other.tag.Equals("Floor"))
		{
			this.Dead ();
		}
		print("player colisao com "+other.name);
	}

    // Update is called once per frame
    void Update()
    {

    }
}