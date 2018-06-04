using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TechExplainFunctions : MonoBehaviour
{

    public GameObject moreInfoPanel;
    public GameObject moreInfoText;
    public GameObject moreInfoNameTag;
    public GameObject mainPanel;
    public List<TextAsset> Assets;
    private List<string>Minigames = new List<string>{"MasterMason","GlassWorker","StoneCutter","Carpenter" };

    void Start()
    {
        int count = 0;
        foreach (TextAsset asset in Assets)
        {
            if (PlayerPrefs.GetInt(Minigames[count]) == 1)
            {
                mainPanel.transform.Find(Minigames[count]).Find("ExplainText").GetComponent<Text>().text = asset.text;
                mainPanel.transform.Find(Minigames[count]).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                mainPanel.transform.Find(Minigames[count]).Find("ExplainText").GetComponent<Text>().text = "Scan het Ambachtspunt om deze tekst vrij te spelen";
                mainPanel.transform.Find(Minigames[count]).GetChild(2).gameObject.SetActive(false);
            }
            count++;
        }


    }


    public void moreInfo(string minigame)
    {
        moreInfoText.GetComponent<Text>().text = mainPanel.transform.Find(minigame).Find("ExplainText").GetComponent<Text>().text;
        moreInfoNameTag.GetComponent<Text>().text = mainPanel.transform.Find(minigame).Find("NameTag").GetComponent<Text>().text;
        moreInfoPanel.SetActive(true);
    }

    public void lessInfo()
    {
        moreInfoPanel.SetActive(false);
    }
}