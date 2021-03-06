﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarpenterScavenge : MonoBehaviour {

    private int partsFound;
    private GameObject gameUI;
    private Text scavengerText;

    // Use this for initialization
    void Start()
    {
        scavengerText = GameObject.Find("ScavengerText").GetComponent<Text>();
        partsFound = 0;
        gameUI = GameObject.Find("GameUICanvas");
        gameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Perform raycast if user clicks/taps the screen
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // If raycast hits something, check if the hit has the right tag
                // If the tag is wrong, do nothing
                if(hit.transform.tag == "Treadmill")
                {
                    // If tag is correct, destroy target and count up
                    Destroy(hit.transform.gameObject);
                    partsFound++;
                    if(partsFound == 1)
                    {
                        scavengerText.text = (partsFound + " deel van tredmolen gevonden");
                    }
                    else
                    {
                        scavengerText.text = (partsFound + " delen van tredmolen gevonden");
                    }

                    // When counter reaches 3, end scavenging part of the minigame
                    if(partsFound == 3)
                    {
                        gameUI.SetActive(true);
                        GameObject.Find("Progress").GetComponent<CarpenterProgress>().EndScavenge();
                        GameObject.Find("ScavengerCanvas").SetActive(false);
                    }
                }
            }
        }
    }
}