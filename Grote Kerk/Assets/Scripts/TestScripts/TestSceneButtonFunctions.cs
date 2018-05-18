using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneButtonFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToMenu()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

    public void ArchitectGame()
    {
        GameManager.Instance.ChangeScene("MasterMason");
    }

    public void CarpenterGame()
    {
        GameManager.Instance.ChangeScene("Carpenter");
    }
}
