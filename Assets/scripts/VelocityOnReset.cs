using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityOnReset : JumpToStartOnReset {
	public Vector2 initialVelocity;

	override public void OnRestart() {
		base.OnRestart();
		this.GetComponent<Rigidbody2D>().velocity = this.initialVelocity;
	}
}
