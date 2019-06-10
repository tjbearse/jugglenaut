using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnReset : MonoBehaviour {
	public void Awake() {
		EventManager.onRestart += this.OnRestart;
	}

	public void OnRestart() {
		this.gameObject.SetActive(true);
	}
}
