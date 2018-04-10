using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsButtonFunctions : MonoBehaviour {

    public AudioMixer audioMixer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Back()
    {
        GameManager.Instance.GoToPreviousScene();
    }

    public void setMusic(float music)
    {
        audioMixer.SetFloat("Music", music);
    }

    public void setDialog(float dialog)
    {
        audioMixer.SetFloat("Dialog", dialog);
    }

    public void MainMenu()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

    public void ResetButton()
    {
        Debug.Log("TODO");
    }

    public void Credits()
    {
        Debug.Log("TODO");
    }
}
