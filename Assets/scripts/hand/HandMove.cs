using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class HandMove : MonoBehaviour {
	public Vector2 movementBound;
	public float maxVel = 15f;
	public float velMult = 10f;
	[SerializeField] public InputActionReference movement;

	private Vector2 input = new Vector2();
	private Vector2 start;
	private bool ignore = false;

	private Vector2 lowerLeft {
		get { return this.start - this.movementBound; }
	}
	private Vector2 upperRight {
		get { return this.start + this.movementBound; }
	}

    void Update() {
		float x = .5f;
		float y = .5f;
		if (!ignore) {
			// [0, 1] rather than [-1,1]
			x = (this.input.x + 1) / 2;
			y = (this.input.y + 1) / 2;
		}
		x = Mathf.Lerp(this.lowerLeft.x, this.upperRight.x, x);
		y = Mathf.Lerp(this.lowerLeft.y, this.upperRight.y, y);
		// max movement speed with lerp?
		Vector2 diff = new Vector2(x,y) - (Vector2)this.transform.position;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(this.velMult * diff, this.maxVel);
    }

	private void OnEnable() {
		this.movement.action.Enable();
		this.movement.action.performed += OnMovementChange;
		this.movement.action.canceled += OnMovementChange;
	}
	private void OnDisable() {
		this.movement.action.Disable();
		this.movement.action.performed -= OnMovementChange;
		this.movement.action.canceled -= OnMovementChange;
	}

    void Start() {
		this.start = this.transform.position;
    }

	public void BlockInput() {
		this.ignore = true;
	}
	public void ResumeInput() {
		this.ignore = false;
	}

	void OnMovementChange(InputAction.CallbackContext context) {
		this.input = context.ReadValue<Vector2>();
	}
}
