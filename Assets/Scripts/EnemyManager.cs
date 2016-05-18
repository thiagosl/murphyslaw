using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public GameObject enemy;
	public float spawnTime;
	public Transform[] spawnPoints;

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn()
	{
		int index = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints[index].position, spawnPoints[index].rotation);
	}
}
