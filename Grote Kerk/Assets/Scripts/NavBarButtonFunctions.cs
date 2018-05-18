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
        if(GameManager.Instance.GetCurrentScene() == "MainGame")
        {
            Debug.Log("Already in test scene");
        }
        else
        {
            Debug.Log("Not in test scene");
            GameManager.Instance.ChangeScene("MainGame");
        }
    }

    public void Map()
    {
        if (GameManager.Instance.GetCurrentScene() == "Map")
        {
            Debug.Log("Already in test scene");
        }
        else
        {
            GameManager.Instance.ChangeScene("Map");
        }
    }

    public void Hints()
    {
        Debug.Log("TODO go to hints screen");
    }

    public void Timeline()
    {
        if (GameManager.Instance.GetCurrentScene() == "Timeline")
        {
            Debug.Log("Already in test scene");
        }
        else
        {
            GameManager.Instance.ChangeScene("Timeline");
        }
    }

    public void Role()
    {
        Debug.Log("TODO go to role screen");
    }

    public void Settings()
    {
        GameManager.Instance.ChangeScene("Settings");
    }
}
