using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabBob : MonoBehaviour {
	[SerializeField] public InputActionReference grabInput;
	public float bobAmount = .4f;

	private void OnEnable() {
		this.grabInput.action.Enable();
		this.grabInput.action.performed += OnGrab;
	}

	private void OnDisable() {
		this.grabInput.action.Disable();
		this.grabInput.action.performed -= OnGrab;
	}

	void OnGrab(InputAction.CallbackContext context) {
		if (context.ReadValue<float>() >= .5f) {
			this.transform.localPosition += Vector3.down * this.bobAmount;
		} else {
			this.transform.localPosition += Vector3.up * this.bobAmount;
		}
	}

}
