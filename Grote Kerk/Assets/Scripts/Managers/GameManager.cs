using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    private GameObject _overlay;

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
}
