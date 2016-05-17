using UnityEngine;
using System.Collections;

public class LevelManeger : MonoBehaviour {
	public void LoadScene (string name) {
            Application.LoadLevel(name);
	}
}
