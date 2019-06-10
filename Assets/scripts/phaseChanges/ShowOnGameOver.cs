using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnGameOver : MonoBehaviour {
	public void Awake() {
		EventManager.onRestart += this.OnRestart;
		EventManager.onGameOver += this.OnGameOver;
		this.gameObject.SetActive(false);
	}

	public void OnRestart() {
		this.gameObject.SetActive(false);
	}
	public void OnGameOver() {
		this.gameObject.SetActive(true);
	}
}
