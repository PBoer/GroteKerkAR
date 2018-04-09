using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Back()
    {
        GameManager.Instance.GoToPreviousScene();
    }

    public void MainMenu()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

    public void ResetButton()
    {
        Debug.Log("TODO");
    }

    public void Credits()
    {
        Debug.Log("TODO");
    }
}
