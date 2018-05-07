using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryCounterScript : MonoBehaviour {

    void OnEnable()
    {
        ProgressManager.OnHistoryUpdate += UpdateHistoryCounter;
    }


    void OnDisable()
    {
        ProgressManager.OnHistoryUpdate -= UpdateHistoryCounter;
    }


    void UpdateHistoryCounter()
    {
        //int MiniGamesDone = PlayerPrefs.GetInt("MasterMasonCompleted")
        //    + PlayerPrefs.GetInt("StoneCutterCompleted")
        //    + PlayerPrefs.GetInt("GlassWorkerCompleted")
        //    + PlayerPrefs.GetInt("CarpenterCompleted");
        //gameObject.GetComponent<Text>().text = MiniGamesDone.ToString() + "/" + ProgressManager.AmountOfMiniGames.ToString();
    }
}
