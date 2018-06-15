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

    /// <summary>
    /// Function to move to the story scene
    /// </summary>
    public void Story()
    {
        if (GameManager.Instance.GetCurrentScene() == "Story")
        {
            Debug.Log("Already in scene");
        }
        else
        {
            GameManager.Instance.ChangeScene("Story");
        }
    }

    /// <summary>
    /// Function to move to the main game scene
    /// </summary>
    public void Scanner()
    {
        if(GameManager.Instance.GetCurrentScene() == "MainGame")
        {
            Debug.Log("Already in scene");
        }
        else
        {
            GameManager.Instance.ChangeScene("MainGame");
        }
    }

    /// <summary>
    /// Function to move to the map scene
    /// </summary>
    public void Map()
    {
        if (GameManager.Instance.GetCurrentScene() == "Map")
        {
            Debug.Log("Already in scene");
        }
        else
        {
            GameManager.Instance.ChangeScene("Map");
        }
    }

    /// <summary>
    /// Function to move to the hints screen
    /// Currently not implemented
    /// </summary>
    public void Hints()
    {
        Debug.Log("TODO go to hints screen");
    }

    /// <summary>
    /// Function to move to the timeline scene
    /// </summary>
    public void Timeline()
    {
        if (GameManager.Instance.GetCurrentScene() == "Timeline")
        {
            Debug.Log("Already in scene");
        }
        else
        {
            GameManager.Instance.ChangeScene("Timeline");
        }
    }

    /// <summary>
    /// Function to move to the technical explanation scene
    /// </summary>
    public void TechnicalExplanation()
    {
        if (GameManager.Instance.GetCurrentScene() == "TechnicalExplanation")
        {
            Debug.Log("Already in scene");
        }
        else
        {
            GameManager.Instance.ChangeScene("TechnicalExplanation");
        }
    }

    /// <summary>
    /// Function to move to the settings scene
    /// </summary>
    public void Settings()
    {
        GameManager.Instance.ChangeScene("Settings");
    }
}
