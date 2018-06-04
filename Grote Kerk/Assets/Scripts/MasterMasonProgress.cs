using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMasonProgress : MonoBehaviour {

    private int blocksPlaced;
    private DialogueScript myDS;
    private GameObject pillars;
    private GameObject arches;
    private GameObject keystones;
    private GameObject top;
    private GameObject centrings;
    private GameObject ribs;
    private GameObject midKeystone;
    

	// Use this for initialization
	void Start () {
        myDS = GameObject.Find("Dialogue").GetComponent<DialogueScript>();
        pillars = GameObject.Find("Pillars");
        arches = GameObject.Find("Arches");
        keystones = GameObject.Find("Keystones");
        centrings = GameObject.Find("Centrings");
        top = GameObject.Find("Top");
        ribs = GameObject.Find("Ribs");
        midKeystone = GameObject.Find("MidKeystone");

        pillars.SetActive(false);
        arches.SetActive(false);
        keystones.SetActive(false);
        top.SetActive(false);
        centrings.SetActive(false);
        ribs.SetActive(false);
        midKeystone.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlacedBlock()
    {
        blocksPlaced++;

        switch (blocksPlaced)
        {
            case 4:
                pillars.SetActive(true);
                break;

            case 8:
                centrings.SetActive(true);
                arches.SetActive(true);
                break;

            case 16:
                keystones.SetActive(true);
                break;

            case 20:
                ribs.SetActive(true);
                break;

            case 24:
                midKeystone.SetActive(true);
                break;

            case 25:
                centrings.SetActive(false);
                top.SetActive(true);
                PlayerPrefs.SetInt("MasterMasonCompleted", 1);
                ProgressManager.UpdateMiniGameCounter();
                myDS.FinishGame();
                break;
        }
    }
}
