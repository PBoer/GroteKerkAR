using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class TrackingTriggers : DefaultTrackableEventHandler
{
    /// <summary>
    /// Function used in the main game scene to trigger minigames
    /// </summary>
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        // Change scene based on which image target was found,
        // if the respective minigame has already been finished, do nothing
        switch (gameObject.name)
        {
            case "MasterMasonCode":
                if(PlayerPrefs.GetInt("MasterMasonCompleted") != 1)
                {
                    GameManager.Instance.ChangeScene("MasterMason");
                }
                break;

            case "CarpenterCode":
                if(PlayerPrefs.GetInt("CarpenterCompleted") != 1)
                {
                    GameManager.Instance.ChangeScene("Carpenter");
                }
                break;
        }
    }
}
