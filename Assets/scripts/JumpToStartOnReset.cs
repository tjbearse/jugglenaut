using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToStartOnReset : MonoBehaviour {
	private Vector2 startPosition;

	public void Awake() {
		EventManager.onRestart += this.OnRestart;
		this.startPosition = this.transform.position;
	}

	public void OnDestroy() {
		EventManager.onRestart -= this.OnRestart;
	}

	virtual public void OnRestart() {
		this.gameObject.SetActive(true);
		this.transform.position = this.startPosition;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
}
