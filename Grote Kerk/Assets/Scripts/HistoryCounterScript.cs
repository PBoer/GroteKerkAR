using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryCounterScript : MonoBehaviour {

    void OnEnable()
    {
        UpdateHistoryCounter();
        ProgressManager.OnHistoryUpdate += UpdateHistoryCounter;
    }


    void OnDisable()
    {
        ProgressManager.OnHistoryUpdate -= UpdateHistoryCounter;
    }


    void UpdateHistoryCounter()
    {
        int historyDone = 0;
        int amountOfHistoryPoints = ProgressManager.AmountOfHistoryPoints;
        for (int i = 0; amountOfHistoryPoints <= i ;i++)
        {
            historyDone = PlayerPrefs.GetInt("HistoryPoint"+ i);
        }
        gameObject.GetComponent<Text>().text = historyDone + "/" + amountOfHistoryPoints;
    }
}
