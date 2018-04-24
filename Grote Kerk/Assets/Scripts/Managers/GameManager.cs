using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    private GameObject _overlay;
    private string previousScene = "MainMenu";
    private string twoScenesBack = "MainMenu";


    void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
        _overlay = GameObject.Find("MainOverlay");
        DisableOverlay();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TestBoop()
    {
        Debug.Log("Success");
    }

    public void EnableOverlay()
    {
        _overlay.SetActive(true);
    }

    public void DisableOverlay()
    {
        _overlay.SetActive(false);
    }

    public void ChangeScene(string scene)
    {
        // prevents player getting stuk in a endless back button loop
        if (GetCurrentScene() != "Instructions" && GetCurrentScene() != previousScene)
        {
            twoScenesBack = previousScene;
            previousScene = GetCurrentScene();
        }
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// sends you back to Previous scene with 2 exeptions
    /// </summary>
    public void GoToPreviousScene()
    {
        // prevents player getting stuk in a endless back button loop
        if (previousScene == "Instructions" || GetCurrentScene() == previousScene)
        {
            ChangeScene(twoScenesBack);
        }
        else
        {
            ChangeScene(previousScene);
        }
    }
}
