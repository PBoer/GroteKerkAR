using System.Collections;
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
        GameManager.Instance.ChangeScene("MainGame");
    }

    public void Instructions()
    {
        GameManager.Instance.ChangeScene("Instructions");
    }

    public void Settings()
    {
        GameManager.Instance.ChangeScene("Settings");
    }
}
