using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance { get; private set; }
    public AudioMixer AudioMixer;

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

    /// <summary>
    /// Function to adjust music volume, using float passed along in the function call
    /// </summary>
    /// <param name="music"></param>
    public void SetMusic(float music)
    {
        AudioMixer.SetFloat("Music", music);
    }

    /// <summary>
    /// Function to adjust dialogue volume, using float passed along in the function call
    /// </summary>
    /// <param name="dialogue"></param>
    public void SetDialog(float dialogue)
    {
        AudioMixer.SetFloat("Dialog", dialogue);
    }
}
