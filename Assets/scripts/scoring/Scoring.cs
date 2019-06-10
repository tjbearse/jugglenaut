using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {
	public delegate void UpdateScore(int i);
	public event UpdateScore OnScoreUpdate;
	private bool disabled = false;

	public int passes {
		get { return _passes; }
		set {
			if (!disabled) {
				_passes = value;
				if (this.OnScoreUpdate != null) {
					this.OnScoreUpdate(_passes);
				}
			}
		}
	}
	private int _passes = -3;

	public float timeElapsed {
		get {
			return this._stopwatch.ElapsedMilliseconds / 1000f;
		}
	}
	private Stopwatch _stopwatch;

	private float TimeDiff(DateTime a, DateTime b) {
		return (float)(a - b).TotalSeconds;
	}

	void Awake() {
		this._stopwatch = new Stopwatch();
	}


	void OnEnable() {
		EventManager.onRestart += this.onRestart;
		EventManager.onGameOver += this.onGameOver;
	}

	void OnDisable() {
		EventManager.onRestart -= this.onRestart;
		EventManager.onGameOver -= this.onGameOver;
	}

	void onRestart() {
		this.disabled = false;
		this._passes = -3;
		this._stopwatch.Restart();
	}

	void onGameOver() {
		this.disabled = true;
		this._stopwatch.Stop();
	}
}
