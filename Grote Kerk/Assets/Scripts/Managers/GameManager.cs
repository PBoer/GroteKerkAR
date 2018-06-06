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
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
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
        if (isLoading)
        {
            if (sceneLoading.isDone)
            {
                DisableLoadingScreen();
                isLoading = false;
            }
        }
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

    public void EnableLoadingScreen()
    {
        _loadingScreen.SetActive(true);
    }


    public void DisableLoadingScreen()
    {
        _loadingScreen.SetActive(false);
    }
    
    public void ChangeScene(string scene)
    {
        if (GetCurrentScene() == "preload")
        {

        }
        else
        {
            isLoading = true;
            EnableLoadingScreen();
        }
        // prevents player getting stuk in a endless back button loop
        if (GetCurrentScene() != "Instructions" && GetCurrentScene() != previousScene)
        {
            twoScenesBack = previousScene;
            previousScene = GetCurrentScene();
        }
        sceneLoading = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        
        
    }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string getPreviousScene()
    {
        return previousScene;
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
