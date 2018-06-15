using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineFunctions : MonoBehaviour {

    public GameObject moreInfoPanel;
    public GameObject moreInfoText;
    public GameObject moreInfoNameTag;
    public GameObject mainPanel;
    public List<TextAsset> Assets;

    void Start()
    {
        int count = 1;

        // Go through PlayerPrefs to see which points have been scanned,
        // Enable text for those that have been scanned
        foreach (TextAsset asset in Assets)
        { 
            if(PlayerPrefs.GetInt("HistoryPoint"+ count) == 1){
                mainPanel.transform.Find("HistoryPoint" + count).Find("HistoryText").GetComponent<Text>().text = asset.text;
                mainPanel.transform.Find("HistoryPoint" + count).GetChild(2).gameObject.SetActive(true);
            }
            else{
                mainPanel.transform.Find("HistoryPoint" + count).Find("HistoryText").GetComponent<Text>().text = "Scan het geschiedenispunt om dit vrij te spelen";
                mainPanel.transform.Find("HistoryPoint" + count).GetChild(2).gameObject.SetActive(false);
            }
            count++;
        }

        
    }

    /// <summary>
    /// Function to open corresponding panel to see all its text
    /// </summary>
    /// <param name="historyPointID"></param>
    public void moreInfo(int historyPointID)
    {
        moreInfoText.GetComponent<Text>().text = mainPanel.transform.Find("HistoryPoint" + historyPointID).Find("HistoryText").GetComponent<Text>().text;
        moreInfoNameTag.GetComponent<Text>().text = mainPanel.transform.Find("HistoryPoint" + historyPointID).Find("NameTag").GetComponent<Text>().text;
        moreInfoPanel.SetActive(true); 
    }

    /// <summary>
    /// Function to close corresponding panel
    /// </summary>
    public void lessInfo()
    {
        moreInfoPanel.SetActive(false);
    }
}
