using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(FixedJoint2D))]
public class HandGrab : MonoBehaviour {
	[SerializeField] public InputActionReference grabInput;
	public Collider2D grabReach;

	private FixedJoint2D grabJoint;
	private Rigidbody2D grabbed {
		get { return this.grabJoint.connectedBody; }
		set {
			this.grabJoint.enabled = (value != null);
			this.grabJoint.connectedBody = value;
		}
	}
	private void Awake() {
		this.grabJoint = this.GetComponent<FixedJoint2D>();
	}

	private void OnEnable() {
		this.grabInput.action.Enable();
		this.grabInput.action.performed += OnGrab;
	}

	private void OnDisable() {
		this.grabInput.action.Disable();
		this.grabInput.action.performed -= OnGrab;
	}

	void OnGrab(InputAction.CallbackContext context) {
		if (!this.grabReach) {
			return;
		}
		// FIXME magic constant
		if (context.ReadValue<float>() >= .5f) {
			// grab
			if (this.grabbed) {
				return;
			}
			// add a filter for only balls
			Collider2D[] results = new Collider2D[1];
			if (this.grabReach.OverlapCollider(new ContactFilter2D().NoFilter(), results) == 1) {
				var rb = results[0].GetComponent<Rigidbody2D>();
				if (!rb) {
					return;
				}
				this.grabbed = rb;
			}
		} else {
			// release
			if (!this.grabbed) {
				return;
			}
			this.grabbed = null;
		}
	}

}
