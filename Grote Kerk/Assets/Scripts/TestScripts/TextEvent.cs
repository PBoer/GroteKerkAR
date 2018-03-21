using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextEvent : MonoBehaviour {

    public bool isTestScene;
    public bool isMainMenu;
    public bool isQuit;
    public bool isBoop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        Debug.Log("Click");
        if (isTestScene)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        if (isMainMenu)
        {
            SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
        }
        if (isBoop)
        {
            GameManager.Instance.TestBoop();
        }
        if (isQuit)
        {

            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
