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

    public void EndScavenge()
    {
        treadmillBase.SetActive(true);
    }

    public void PlacedPart()
    {
        partsPlaced++;

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
