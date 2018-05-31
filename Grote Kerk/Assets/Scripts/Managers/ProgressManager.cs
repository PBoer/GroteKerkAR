using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour {

    public static ProgressManager Instance { get; private set; }


    public const int AmountOfMiniGames = 4;
    public const int AmountOfHistoryPoints = 14;

    //public GameObject TimePieceCounter;
    //public GameObject MiniGameCounter;

    private void OnEnable()
    {
        UpdateTimePieceCounter();
        UpdateMiniGameCounter();
    }

    public static void UpdateTimePieceCounter()
    {
        int historyDone = 0;
        for (int i = 1; i <= AmountOfHistoryPoints; i++)
        {
            if (PlayerPrefs.GetInt("HistoryPoint" + i) == 1)
            {
                historyDone++; 
            }
        }
        
        GameObject obj = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("HistoryCounter"));
        obj.GetComponent<Text>().text = historyDone + "/" + AmountOfHistoryPoints;
    }

    public static void UpdateMiniGameCounter()
    {
        int MiniGamesDone = PlayerPrefs.GetInt("MasterMasonCompleted")
            + PlayerPrefs.GetInt("StoneCutterCompleted")
            + PlayerPrefs.GetInt("GlassWorkerCompleted")
            + PlayerPrefs.GetInt("CarpenterCompleted");
        GameObject obj = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("MinigameCounter"));
        obj.GetComponent<Text>().text = MiniGamesDone + "/" + AmountOfMiniGames;
    }
}
