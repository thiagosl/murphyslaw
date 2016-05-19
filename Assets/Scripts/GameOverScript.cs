using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameOverScript : MonoBehaviour {
	public Text lastScore;

	void Start () {
		LoadLastScore ();
	}

	void LoadLastScore(){
		if (File.Exists (Application.persistentDataPath+"/highscore.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath+"/highscore.dat", FileMode.Open);
			HighScore h = (HighScore) bf.Deserialize (file);
			this.lastScore.text = "YOUR SCORE: " + h.scoreData;
			file.Close();
		} else {
			this.lastScore.text = "YOUR SCORE: 0";
		}
	}
}
