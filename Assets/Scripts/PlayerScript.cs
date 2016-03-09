using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool facingRight;
    private Rigidbody2D rb;
    private Transform tf;

    // Use this for initialization
    void Start()
    {
        this.speed = 3f;
        this.jumpForce = 300f;
        this.facingRight = true;
        this.rb = GetComponent<Rigidbody2D>();
        this.tf = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontalMoviment = Input.GetAxis("Horizontal");
        if (horizontalMoviment < 0 && facingRight)
        {
            this.facingRight = false;
            this.FlipSprite();
        }
        else if(horizontalMoviment > 0 && !facingRight)
        {
            this.facingRight = true;
            this.FlipSprite();
        }
        rb.velocity = new Vector2(horizontalMoviment * speed, rb.velocity.y);
    }

    private void FlipSprite()
    {
        Vector3 scale = tf.localScale;
        scale.x *= -1;
        tf.localScale = scale;
    }

    private void Jump()
    {
        if (Input.GetKeyDown("up") && rb.velocity.y == 0)
        {
            this.rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}