using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {
    public float bgVelocity;
    private GameObject player;
    private Material mat;
    private float textureOffset;


	// Use this for initialization
	void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.mat = GetComponent<Renderer>().material;
        this.textureOffset = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float playerVelocity = player.GetComponent<Rigidbody2D>().velocity.x;
        if (playerVelocity != 0f)
        {
            float side = player.GetComponent<Transform>().localScale.x;
            textureOffset += bgVelocity*side;
            if (textureOffset > 1.0f)
            {
                textureOffset -= 1.0f;
            }
            mat.mainTextureOffset = new Vector2(textureOffset, 0);
        }
	}
}
