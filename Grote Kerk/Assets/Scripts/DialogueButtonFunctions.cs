using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButtonFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SkipDialogue()
    {
        GameObject.Find("DialogueCanvas").SetActive(false);
    }

    public void ForwardDialogue()
    {

    }
}
