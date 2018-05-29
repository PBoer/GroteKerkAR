using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class TrackingTriggers : DefaultTrackableEventHandler
{

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        switch (gameObject.name)
        {
            case "MasterMasonCode":
                if(PlayerPrefs.GetInt("MasterMasonCompleted") != 1)
                {
                    GameManager.Instance.ChangeScene("MasterMason");
                }
                break;
        }
    }
}
