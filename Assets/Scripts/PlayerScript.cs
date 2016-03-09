using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private float speed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
    void FixedUpdate() {
        Move();
    }

    void Move() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float mov = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(mov*speed, rb.velocity.y);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
