using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerRestart : MonoBehaviour {
	[SerializeField] public InputActionReference resetInput;
	private void TriggerReset(InputAction.CallbackContext context) {
		EventManager.Restart();
	}

	private void OnEnable() {
		this.resetInput.action.Enable();
		this.resetInput.action.performed += TriggerReset;
	}

	private void OnDisable() {
		this.resetInput.action.Disable();
		this.resetInput.action.performed -= TriggerReset;
	}

}
