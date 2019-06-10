using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Lost : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "ball") {
			EventManager.GameOver();
		}
	}
}
