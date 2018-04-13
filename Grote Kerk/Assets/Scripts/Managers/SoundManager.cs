using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    public static AudioClip testSound;
    public static SoundManager Instance { get; private set; }
    public AudioMixer audioMixer;

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

    public void SetMusic(float music)
    {
        audioMixer.SetFloat("Music", music);
    }

    public void SetDialog(float dialog)
    {
        audioMixer.SetFloat("Dialog", dialog);
    }
}
