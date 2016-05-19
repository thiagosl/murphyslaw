using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MenuScript : MonoBehaviour {
	public Text score;

	void Start () {
		LoadScore ();
	}

	void LoadScore(){
		if (File.Exists (Application.persistentDataPath+"/highscore.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath+"/highscore.dat", FileMode.Open);
			HighScore h = (HighScore) bf.Deserialize (file);
			this.score.text = "BEST SCORE: "+h.highScoreData+"\nLAST SCORE: " + h.scoreData;
			file.Close();
		} else {
			this.score.text = "BEST SCORE: 0\nYOUR SCORE: 0";
		}
	}
}

