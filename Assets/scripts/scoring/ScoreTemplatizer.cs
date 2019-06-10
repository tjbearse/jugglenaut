using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class ScoreTemplatizer : MonoBehaviour {
	public Scoring scoring;

	void OnEnable() {
		this.scoring.OnScoreUpdate += this.OnScoreUpdate;
	}

	void OnDisable() {
		this.scoring.OnScoreUpdate -= this.OnScoreUpdate;
	}

	void OnScoreUpdate(int i) {
		var t = this.GetComponent<Text>();
		t.text = String.Format("Passes: {0}", i);
	}
}
