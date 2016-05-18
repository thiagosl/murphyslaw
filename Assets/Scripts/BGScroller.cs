using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {
	public float bgVelocity;
	private Material mat;
	private float textureOffset;

	void Start () {
		this.mat = GetComponent<Renderer>().material;
		this.textureOffset = 0f;
	}

	void Update () {
		float side = 2.0f;
		textureOffset += bgVelocity*side;
		if (textureOffset > 1.0f) {
			textureOffset -= 1.0f;
		}
		mat.mainTextureOffset = new Vector2(textureOffset, 0);
	}
}