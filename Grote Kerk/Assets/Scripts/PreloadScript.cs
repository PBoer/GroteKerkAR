﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
