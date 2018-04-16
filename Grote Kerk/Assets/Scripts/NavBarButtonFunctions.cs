using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavBarButtonFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Story()
    {
        Debug.Log("TODO go to story screen");
    }

    public void Scanner()
    {
        if(GameManager.Instance.GetCurrentScene() == "TestScene")
        {
            Debug.Log("Already in test scene");
        }
        else
        {
            Debug.Log("Not in test scene");
            GameManager.Instance.ChangeScene("TestScene");
        }
    }

    public void Map()
    {
        Debug.Log("TODO go to map screen");
    }

    public void Hints()
    {
        Debug.Log("TODO go to hints screen");
    }

    public void Timeline()
    {
        Debug.Log("TODO go to timeline screen");
    }

    public void Role()
    {
        Debug.Log("TODO go to role screen");
    }

    public void Settings()
    {
        Debug.Log("TODO go to in-game settings screen");
    }
}
