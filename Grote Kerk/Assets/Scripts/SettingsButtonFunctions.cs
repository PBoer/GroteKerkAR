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
        // See if volume values already exist in PlayerPrefs,
        // if so, adjust sliders to those values
        if(PlayerPrefs.HasKey("Music")&& PlayerPrefs.HasKey("Music"))
        {
            MusicSlider.value = PlayerPrefs.GetFloat("Music");
            SpeechSlider.value= PlayerPrefs.GetFloat("Dialog");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Function to go back to the previous scene
    /// </summary>
    public void Back()
    {
        GameManager.Instance.GoToPreviousScene();
    }

    /// <summary>
    /// Function to set music volume, using float passed on by the slider that triggers this function
    /// </summary>
    /// <param name="music"></param>
    public void SetMusic(float music)
    {
        SoundManager.Instance.SetMusic(music);
        PlayerPrefs.SetFloat("Music", music);
    }

    /// <summary>
    /// Function to set dialogue volume, using float passed on by the slider that triggers this function
    /// </summary>
    /// <param name="dialog"></param>
    public void SetDialog(float dialog)
    {
        SoundManager.Instance.SetDialog(dialog);
        PlayerPrefs.SetFloat("Dialog", dialog);
    }

    /// <summary>
    /// Function to go to the main menu
    /// </summary>
    public void MainMenu()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

    /// <summary>
    /// Function to open the reset panel, in which a player can reset their game progress
    /// </summary>
    public void OpenResetPanel()
    {
        ResetPanel.SetActive(true);
    }

    /// <summary>
    /// Function to show credits screen
    /// </summary>
    public void Credits()
    {
        CreditsPanel.SetActive(true);
    }

    /// <summary>
    /// Function to cancel reset
    /// </summary>
    public void CancelReset()
    {
        ResetPanel.SetActive(false);
    }

    /// <summary>
    /// Function to go to the instructions scene
    /// </summary>
    public void Instructions()
    {
        GameManager.Instance.ChangeScene("Instructions");
    }

    /// <summary>
    /// Function to reset game progress
    /// </summary>
    public void ResetProgress()
    {
        // Since progress is saved in PlayerPrefs, delete all PlayerPrefs,
        // then set the music and dialog playerprefs to the value of their respective sliders
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Music", MusicSlider.value);
        PlayerPrefs.SetFloat("Dialog", SpeechSlider.value);
        // Update the counters in the navigation bar
        ProgressManager.UpdateTimePieceCounter();
        ProgressManager.UpdateMiniGameCounter();
        ResetPanel.SetActive(false);
    }
}
