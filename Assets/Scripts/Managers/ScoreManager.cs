using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public GUIText scoreText;
	public int score;

	void Start () {
		this.score = 0;
		this.UpdateScore();
	}

	public void IncrementScore(int newScore) {
		this.score += newScore;
		this.UpdateScore ();
	}

	void UpdateScore () {
		if (score == 0) {
			this.scoreText.text = "SCORE: 0000";
		} else if (score < 10) {
			this.scoreText.text = "SCORE: 000" + score;
		} else if (score < 100) {
			this.scoreText.text = "SCORE: 00" + score;
		} else if (score < 1000) {
			this.scoreText.text = "SCORE: 0" + score;
		} else {
			this.scoreText.text = "SCORE: " + score;
		}
	}
}
