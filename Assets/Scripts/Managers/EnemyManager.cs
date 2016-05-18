using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour {
	public GameObject enemy;
	public float spawnTime;
	public Transform[] spawnPoints;

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn()
	{
		int index = UnityEngine.Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints[index].position, spawnPoints[index].rotation);
	}
}
