using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreloadScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Once preload is complete, automatically move on to the main menu
        GameManager.Instance.ChangeScene("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
