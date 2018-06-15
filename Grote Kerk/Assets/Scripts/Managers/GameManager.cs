using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    private GameObject _overlay;
    private GameObject _loadingScreen;
    private AsyncOperation sceneLoading;
    private bool isLoading;
    private string previousScene = "MainMenu";
    private string twoScenesBack = "MainMenu";


    void Awake()
    {
        // Fill static object. If static object is already filled, log a warning
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }

        // Fill overlay and loadingscreen variables with their respective objects, then disable them
        _overlay = GameObject.Find("MainOverlay");
        _loadingScreen = GameObject.Find("LoadScreen");
        DisableOverlay();
        DisableLoadingScreen();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // If game is finished loading, disable loading screen again
        if (isLoading)
        {
            if (sceneLoading.isDone)
            {
                DisableLoadingScreen();
                isLoading = false;
            }
        }
	}

    /// <summary>
    /// Function to enable the navigation bar
    /// </summary>
    public void EnableOverlay()
    {
        _overlay.SetActive(true);
    }

    /// <summary>
    /// Function to disable the navigation bar
    /// </summary>
    public void DisableOverlay()
    {
        _overlay.SetActive(false);
    }

    /// <summary>
    /// Function to enable the loading screen
    /// </summary>
    public void EnableLoadingScreen()
    {
        _loadingScreen.SetActive(true);
    }

    /// <summary>
    /// Function to disable the loading screen
    /// </summary>
    public void DisableLoadingScreen()
    {
        _loadingScreen.SetActive(false);
    }
    
    /// <summary>
    /// Function to change to the scene with the name given in the function call
    /// </summary>
    /// <param name="scene"></param>
    public void ChangeScene(string scene)
    {
        // Enable loading screen unless the current scene is the preload scene
        if (GetCurrentScene() == "preload")
        {

        }
        else
        {
            isLoading = true;
            EnableLoadingScreen();
        }
        // Prevents player getting stuck in an endless back button loop
        if (GetCurrentScene() != "Instructions" && GetCurrentScene() != previousScene)
        {
            twoScenesBack = previousScene;
            previousScene = GetCurrentScene();
        }

        // Load next scene asynchronously and keep track so the loading screen can be disabled when done loading
        sceneLoading = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        
        
    }

    /// <summary>
    /// Function to get the name of the current scene
    /// </summary>
    /// <returns></returns>
    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// Function to get the name of the previous scene
    /// </summary>
    /// <returns></returns>
    public string getPreviousScene()
    {
        return previousScene;
    }

    /// <summary>
    /// Sends you back to previous scene with 2 exceptions
    /// </summary>
    public void GoToPreviousScene()
    {
        // prevents player getting stuck in an endless back button loop
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
