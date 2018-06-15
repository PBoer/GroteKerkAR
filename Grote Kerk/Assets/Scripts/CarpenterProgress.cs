using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpenterProgress : MonoBehaviour {

    private int partsPlaced;
    private DialogueScript myDS;
    private GameObject treadmillBase;
    private GameObject treadmillWheel;
    private GameObject treadmillTop;


    private void Awake()
    {
        myDS = GameObject.Find("Dialogue").GetComponent<DialogueScript>();
    }
    // Use this for initialization
    void Start () {

        treadmillBase = GameObject.Find("Treadmill_Base");
        treadmillWheel = GameObject.Find("Treadmill_Wheel");
        treadmillTop = GameObject.Find("Treadmill_Top");

        treadmillBase.SetActive(false);
        treadmillWheel.SetActive(false);
        treadmillTop.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Function to enable second part of the minigame, placement of treadmill parts,
    /// by enabling objects on which player has to drag the found parts
    /// </summary>
    public void EndScavenge()
    {
        treadmillBase.SetActive(true);
    }

    /// <summary>
    /// Function to count the amount of parts placed and act accordingly
    /// </summary>
    public void PlacedPart()
    {
        partsPlaced++;

        // If only one or two parts have been placed, enable next object on which player has to drag parts
        // If three parts have been placed, end minigame
        switch (partsPlaced)
        {
            case 1:
                treadmillTop.SetActive(true);
                break;

            case 2:
                treadmillWheel.SetActive(true);
                break;

            case 3:
                PlayerPrefs.SetInt("CarpenterCompleted", 1);
                ProgressManager.UpdateMiniGameCounter();
                myDS.FinishGame();
                break;
        }

    }
}
