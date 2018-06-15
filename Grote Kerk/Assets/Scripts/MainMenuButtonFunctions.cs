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

    /// <summary>
    /// Function to start the game
    /// </summary>
    public void StartGame()
    {
        // Check if player has already seen story,
        // if so, move to map scene. If not, move to story scene
        if (PlayerPrefs.GetInt("StorySeen") == 1)
        {
            GameManager.Instance.ChangeScene("Map");
        }
        else
        {
            GameManager.Instance.ChangeScene("Story");
        }
        
    }

    /// <summary>
    /// Function to change to the instructions scene
    /// </summary>
    public void Instructions()
    {
        GameManager.Instance.ChangeScene("Instructions");
    }

    /// <summary>
    /// Function to change to the settings scene
    /// </summary>
    public void Settings()
    {
        GameManager.Instance.ChangeScene("Settings");
    }
}
