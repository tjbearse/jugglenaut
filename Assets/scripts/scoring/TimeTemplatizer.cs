using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class TimeTemplatizer : MonoBehaviour {
	public Scoring scoring;

	void Update() {
		var time = this.scoring.timeElapsed;
		var t = this.GetComponent<Text>();
		t.text = String.Format("Time: {0:F1}", time);
	}
}
