using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOverlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Disable the navigation bar overlay in any scene this object is in
        GameManager.Instance.DisableOverlay();
	}
}
