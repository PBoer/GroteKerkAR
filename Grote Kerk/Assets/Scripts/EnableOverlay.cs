using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOverlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Enable navigation bar overlay in any scene this object is in
        GameManager.Instance.EnableOverlay();
	}
}
