using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private Transform playerTransform;
    private Transform cameraTransform;

	// Use this for initialization
	void Start () {
        this.playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.cameraTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        cameraTransform.position = new Vector3(playerTransform.position.x, cameraTransform.position.y, cameraTransform.position.z);
	}
}
