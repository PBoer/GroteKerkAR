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


    private void Awake()
    {
        myDS = GameObject.Find("Dialogue").GetComponent<DialogueScript>();
    }
    // Use this for initialization
    void Start () {
        // Fill variables with the objects that are part of the 3d cross vault model,
        // then disable them
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

    /// <summary>
    /// Function called by an object when it is placed in the correct position,
    /// to progress the game
    /// </summary>
    public void PlacedBlock()
    {
        blocksPlaced++;

        // Check how many objects have been placed, then show the next part of the minigame when needed (show pillars when 4 bases have been placed, etc)
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
                midKeystone.SetActive(true);
                centrings.SetActive(false);
                break;

            // When all objects have been placed, finish game
            case 21:
                top.SetActive(true);
                PlayerPrefs.SetInt("MasterMasonCompleted", 1);
                ProgressManager.UpdateMiniGameCounter();
                myDS.FinishGame();
                break;
        }
    }
}
