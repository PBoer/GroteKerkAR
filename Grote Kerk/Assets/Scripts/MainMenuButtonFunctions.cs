﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        GameManager.Instance.ChangeScene("TestScene");
    }

    public void Instructions()
    {
        Debug.Log("Instructies TODO");
    }

    public void Settings()
    {
        Debug.Log("Instellingen TODO");
    }
}