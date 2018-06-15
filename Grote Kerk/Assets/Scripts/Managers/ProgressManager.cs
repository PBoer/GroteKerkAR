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

    /// <summary>
    /// Function to update the timepiece counter in the navigation bar
    /// </summary>
    public static void UpdateTimePieceCounter()
    {
        // Count the amount of history points scanned by going through PlayerPrefs
        int historyDone = 0;
        for (int i = 1; i <= AmountOfHistoryPoints; i++)
        {
            if (PlayerPrefs.GetInt("HistoryPoint" + i) == 1)
            {
                historyDone++; 
            }
        }
        
        // Update the text field containing the number of timepieces scanned
        GameObject obj = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("HistoryCounter"));
        obj.GetComponent<Text>().text = historyDone + "/" + AmountOfHistoryPoints;
    }

    /// <summary>
    /// Function to update the minigame counter in the navigation bar
    /// </summary>
    public static void UpdateMiniGameCounter()
    {
        // Count the amount of minigames finished by going through the PlayerPrefs
        int MiniGamesDone = PlayerPrefs.GetInt("MasterMasonCompleted")
            + PlayerPrefs.GetInt("StoneCutterCompleted")
            + PlayerPrefs.GetInt("GlassWorkerCompleted")
            + PlayerPrefs.GetInt("CarpenterCompleted");

        // Update the text field containing the number of minigames finished
        GameObject obj = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("MinigameCounter"));
        obj.GetComponent<Text>().text = MiniGamesDone + "/" + AmountOfMiniGames;
    }
}
