using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static AudioClip testSound;
    public static SoundManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }

    // Use this for initialization
    void Start () {
        //testSound = Resources.Load<AudioClip> ("");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
