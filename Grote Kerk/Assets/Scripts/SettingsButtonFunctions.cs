using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonFunctions : MonoBehaviour {

    public Slider MusicSlider;
    public Slider SpeechSlider;
    public GameObject CreditsPanel;
    public GameObject ResetPanel;

    // Use this for initialization
    void Start () {
        if(PlayerPrefs.HasKey("Music")&& PlayerPrefs.HasKey("Music"))
        {
            MusicSlider.value = PlayerPrefs.GetFloat("Music");
            SpeechSlider.value= PlayerPrefs.GetFloat("Dialog");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Back()
    {
        GameManager.Instance.GoToPreviousScene();
    }

    public void SetMusic(float music)
    {
        SoundManager.Instance.SetMusic(music);
        PlayerPrefs.SetFloat("Music", music);
    }

    public void SetDialog(float dialog)
    {
        SoundManager.Instance.SetDialog(dialog);
        PlayerPrefs.SetFloat("Dialog", dialog);
    }

    public void MainMenu()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

    public void OpenResetPanel()
    {
        ResetPanel.SetActive(true);
    }

    public void Credits()
    {
        CreditsPanel.SetActive(true);
    }

    public void CancelReset()
    {
        ResetPanel.SetActive(false);
    }

    public void Instructions()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Music", MusicSlider.value);
        PlayerPrefs.SetFloat("Dialog", SpeechSlider.value);
        ResetPanel.SetActive(false);
    }
}
