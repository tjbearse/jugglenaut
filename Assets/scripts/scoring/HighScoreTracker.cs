using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class HighScoreTracker : MonoBehaviour {
	public Scoring score;
	private int highScore = 0;
	private float highTime = 0;

	void OnEnable() {
		var t = this.GetComponent<Text>();
		t.text = GetScoreText() + "\n" + GetTimeText();
	}

	string GetScoreText() {
		int newScore = this.score.passes;
		var t = this.GetComponent<Text>();
		if (newScore <= this.highScore) {
			return String.Format("High Score: {0}", this.highScore);
		} else {
			this.highScore = newScore;
			return String.Format("New High Score!: {0}", this.highScore);
		}

	}

	string GetTimeText() {
		float newTime = this.score.timeElapsed;
		if (newTime <= this.highTime) {
			return String.Format("Best Time: {0:F1}s", this.highTime);
		} else {
			this.highTime = newTime;
			return String.Format("New Best Time!: {0:F1}s", this.highTime);
		}

	}
}
