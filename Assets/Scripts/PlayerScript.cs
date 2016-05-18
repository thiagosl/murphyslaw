using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
	//public CameraScript camera;

    private bool facingRight;
	private float offset;
    private Rigidbody2D rb;
    private Transform tf;
    private Animator playerAnimator;

    // Use this for initialization
    void Start()
    {
        this.speed = 4f;
        this.jumpForce = 350f;
        this.facingRight = true;
		this.offset = 0f;
        this.rb = GetComponent<Rigidbody2D>();
        this.tf = GetComponent<Transform>();
        this.playerAnimator = GetComponent<Animator>();
        this.playerAnimator.SetBool("Walking", false);
        this.playerAnimator.SetBool("Jumping", false);
    }

    void FixedUpdate()
    {
		InfinitRunnerMove ();
        Jump();
    }

	private void InfinitRunnerMove ()
	{
		rb.velocity = new Vector2(speed, rb.velocity.y);
		playerAnimator.SetBool("Walking", true);
		//float horizontalMoviment = Input.GetAxis("Horizontal");
		//this.speed += horizontalMoviment/2;
		//camera.transform.position.x;
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
		if (other.tag.Equals ("Enemy")) {
			this.Dead ();
		}
	}
}