using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameCounterScript : MonoBehaviour {

    void OnEnable()
    {
        UpdateMiniGameCounter();
        ProgressManager.OnMiniGameUpdate += UpdateMiniGameCounter;
    }


    void OnDisable()
    {
        ProgressManager.OnMiniGameUpdate -= UpdateMiniGameCounter;
    }


    void UpdateMiniGameCounter()
    {
        int MiniGamesDone = PlayerPrefs.GetInt("MasterMasonCompleted")
            + PlayerPrefs.GetInt("StoneCutterCompleted")
            + PlayerPrefs.GetInt("GlassWorkerCompleted")
            + PlayerPrefs.GetInt("CarpenterCompleted");
        gameObject.GetComponent<Text>().text = MiniGamesDone.ToString() + "/" + ProgressManager.AmountOfMiniGames.ToString();
    }
}
