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
        if (GameManager.Instance.GetCurrentScene() == "Story")
        {
            Debug.Log("Already in test scene");
        }
        else
        {
            GameManager.Instance.ChangeScene("Story");
        }
    }

    public void Scanner()
    {
        if(GameManager.Instance.GetCurrentScene() == "MainGame")
        {
            Debug.Log("Already in test scene");
        }
        else
        {
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

    public void TechnicalExplanation()
    {
        if (GameManager.Instance.GetCurrentScene() == "TechnicalExplanation")
        {
            Debug.Log("Already in test scene");
        }
        else
        {
            GameManager.Instance.ChangeScene("TechnicalExplanation");
        }
    }

    public void Settings()
    {
        GameManager.Instance.ChangeScene("Settings");
    }
}
