using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapFunctions : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnEnable()
    {
        updateTimePieceMarker();
        updateMiniGameMarker();
    }

    private void updateMiniGameMarker()
    {
        var MinGamesDone = Resources.FindObjectsOfTypeAll<GameObject>().Where<GameObject>(g => g.CompareTag("MiniGameDone"));
        foreach (GameObject MinGameDone in MinGamesDone)
        {
            //takes the int at the end of the gameobject name. This is done to make sure you always have the right timepiece
            if (PlayerPrefs.GetInt(MinGameDone.name + "Completed") == 1)
            {
                MinGameDone.SetActive(true);
            }
            else
            {
                MinGameDone.SetActive(false);
            }
        }
    }

    private void updateTimePieceMarker()
    {
        var TimePiecesDone = Resources.FindObjectsOfTypeAll<GameObject>().Where<GameObject>(g => g.CompareTag("TimePieceDone"));
        foreach (GameObject TimePieceDone in TimePiecesDone)
        {
            //takes the int at the end of the gameobject name. This is done to make sure you always have the right timepiece
            if (PlayerPrefs.GetInt("HistoryPoint" + (TimePieceDone.name.Substring(TimePieceDone.name.LastIndexOf("e") + 1))) == 1)
            {
                TimePieceDone.SetActive(true);
            }
            else
            {
                TimePieceDone.SetActive(false);
            }
        }
    }
}
