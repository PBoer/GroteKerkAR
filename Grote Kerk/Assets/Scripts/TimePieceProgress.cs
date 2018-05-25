using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePieceProgress : DefaultTrackableEventHandler{

    public int TimePieceId;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        PlayerPrefs.SetInt("HistoryPoint" + TimePieceId, 1);
        ProgressManager.UpdateTimePieceCounter();
    }
}
