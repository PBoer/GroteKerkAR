﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimelineFunctions : MonoBehaviour {

    public GameObject moreInfoPanel;
    public GameObject moreInfoText;
    public GameObject mainPanel;
    public List<TextAsset> Assets;

    void Start()
    {
        int count = 1;
        foreach (TextAsset asset in Assets)
        {
            //TODO uncomment with 
            //if(PlayerPrefs.GetInt("HistoryPoint"+ count) == 1){
            mainPanel.transform.Find("HistoryPoint" + count).Find("HistoryText").GetComponent<Text>().text = asset.text;
            //}
            //else{
            //mainPanel.transform.Find("HistoryPoint" + count).Find("HistoryText").GetComponent<Text>().text = "Scan het geschiedenispunt om dit vrij te spelen";
            //}
            count++;
        }

        
    }


    public void moreInfo(int historyPointID)
    {
        moreInfoText.GetComponent<Text>().text = mainPanel.transform.Find("HistoryPoint" + historyPointID).Find("HistoryText").GetComponent<Text>().text;
        moreInfoPanel.SetActive(true); 
    }

    public void lessInfo()
    {
        moreInfoPanel.SetActive(false);
    }
}
