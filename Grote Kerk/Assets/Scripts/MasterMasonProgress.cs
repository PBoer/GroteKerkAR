using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMasonProgress : MonoBehaviour {

    private int blocksPlaced;
    private DialogueScript myDS;
    

	// Use this for initialization
	void Start () {
        myDS = GameObject.Find("Dialogue").GetComponent<DialogueScript>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlacedBlock()
    {
        blocksPlaced++;

        if(blocksPlaced == 10)
        {
            myDS.FinishGame();
        }
    }
}
