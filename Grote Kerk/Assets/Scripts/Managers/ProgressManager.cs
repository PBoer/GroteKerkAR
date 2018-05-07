using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {

    public delegate void ProgressHistory();
    public static event ProgressHistory OnHistoryUpdate;

    public delegate void ProgressMiniGame();
    public static event ProgressMiniGame OnMiniGameUpdate;

    public const int AmountOfMiniGames = 4;
    public const int AmountOfHistoryPoints = 14;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnHistoryPointScan()
    {
        if (OnHistoryUpdate != null)
        {
            OnHistoryUpdate();
        }
            
    }

    public void OnMiniGamePointScan()
    {
        if (OnMiniGameUpdate != null)
        {
            OnMiniGameUpdate();
        }

    }
}
