using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private Animator playerAnimator;

    void Start()
    {
        this.speed = 10f;
        this.jumpForce = 50000f;
        this.rb = GetComponent<Rigidbody2D>();
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
		playerAnimator.SetBool("Walking", true);
		float horizontalMoviment = Input.GetAxis("Horizontal");
		Vector2 playerPosScreen = Camera.main.WorldToScreenPoint(transform.position);
		if (horizontalMoviment < 0) {
			if (playerPosScreen.x > 30.0f) {
				rb.velocity = new Vector2 (-speed, rb.velocity.y);
			} else {
				rb.velocity = new Vector2 (0, rb.velocity.y);
			}
		} else if (horizontalMoviment > 0) {
			if (playerPosScreen.x < Screen.width - 30.0f) {
				rb.velocity = new Vector2 (speed, rb.velocity.y);
			} else {
				rb.velocity = new Vector2 (0, rb.velocity.y);
			}
		} else {
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
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