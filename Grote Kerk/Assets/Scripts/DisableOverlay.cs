using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOverlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.Instance.DisableOverlay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
