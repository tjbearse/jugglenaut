using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class PassAccumulator : MonoBehaviour {
	public Scoring scoring;
	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "ball") {
			this.scoring.passes++;
		}
	}
}
