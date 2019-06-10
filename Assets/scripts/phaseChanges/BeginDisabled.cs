using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginDisabled : MonoBehaviour
{
    void Start() {
		this.gameObject.SetActive(false);
    }
}
