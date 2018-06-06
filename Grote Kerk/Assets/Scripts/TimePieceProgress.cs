using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePieceProgress : DefaultTrackableEventHandler{

    public int TimePieceId;
    public GameObject ScanDonePopup;
    public GameObject Canvas;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        PlayerPrefs.SetInt("HistoryPoint" + TimePieceId, 1);
        ProgressManager.UpdateTimePieceCounter();
        Canvas.SetActive(true);
        ScanDonePopup.SetActive(true);
        StartCoroutine(FadeTextToZeroAlpha(3f, ScanDonePopup.GetComponent<Text>()));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {

        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1); 
        ScanDonePopup.SetActive(false);
        Canvas.SetActive(false);
        yield break;
    }
}
