using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreManager : MonoBehaviour {

	public GUIText scoreText;
	private int score;
	private int highScore;

	void Start () {
		this.score = 0;
		this.LoadHighScore ();
	}

	public void IncrementScore(int newScore) {
		this.score += newScore;
		if (score > highScore) {
			highScore = score;
		}
		this.UpdateScore ();
	}

	void UpdateScore () {
		if (score == 0) {
			this.scoreText.text = "BEST: "+highScore+"\nSCORE: 0000";
		} else if (score < 10) {
			this.scoreText.text = "BEST: "+highScore+"\nSCORE: 000" + score;
		} else if (score < 100) {
			this.scoreText.text = "BEST: "+highScore+"\nSCORE: 00" + score;
		} else if (score < 1000) {
			this.scoreText.text = "BEST: "+highScore+"\nSCORE: 0" + score;
		} else {
			this.scoreText.text = "BEST: "+highScore+"\nSCORE: " + score;
		}
	}

	public void SaveHighScore(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath+"/highscore.dat");
		HighScore h = new HighScore ();
		h.highScoreData = this.highScore;
		h.scoreData = this.score;
		bf.Serialize (file, h);
		file.Close ();
	}

	void LoadHighScore(){
		if (File.Exists (Application.persistentDataPath+"/highscore.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath+"/highscore.dat", FileMode.Open);
			HighScore h = (HighScore) bf.Deserialize (file);
			this.highScore = h.highScoreData;
			file.Close ();
		} else {
			highScore = 0;
		}
		this.UpdateScore ();
	}
}

[Serializable]
class HighScore{
	public int scoreData;
	public int highScoreData;
}
