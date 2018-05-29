using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpenterScavenge : MonoBehaviour {

    private int partsFound;
    private GameObject gameUI;

    // Use this for initialization
    void Start()
    {
        partsFound = 0;
        gameUI = GameObject.Find("GameUICanvas");
        gameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Treadmill")
                {
                    Destroy(hit.transform.gameObject);
                    partsFound++;

                    if(partsFound == 3)
                    {
                        gameUI.SetActive(true);
                        GameObject.Find("Progress").GetComponent<CarpenterProgress>().EndScavenge();
                    }
                }
            }
        }
    }
}