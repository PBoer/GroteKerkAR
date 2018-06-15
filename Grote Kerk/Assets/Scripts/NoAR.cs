using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class NoAR : MonoBehaviour
{
    //Class to be used in any scene that does not require AR, to disable the AR camera. Necessary due to the way Vuforia's AR camera works.

    // Use this for initialization
    void Start()
    {

        Camera mainCamera = Camera.main;
        if (mainCamera)
        {
            if (mainCamera.GetComponent<VuforiaBehaviour>() != null)
            {
                mainCamera.GetComponent<VuforiaBehaviour>().enabled = false;
            }
            if (mainCamera.GetComponent<VideoBackgroundBehaviour>() != null)
            {
                mainCamera.GetComponent<VideoBackgroundBehaviour>().enabled = false;
            }
            if (mainCamera.GetComponent<DefaultInitializationErrorHandler>() != null)
            {
                mainCamera.GetComponent<DefaultInitializationErrorHandler>().enabled = false;
            }
        }
    }

}
