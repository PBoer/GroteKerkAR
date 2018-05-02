using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    public float letterPause = 0.2f;
    public AudioClip sound;

    private string scene;
    private GameObject dialogueCanvas;
    private int dialogueCount;
    private List<string> messages;
    private string message;
    private Text myText;

    // Use this for initialization
    void Start()
    {
        // Find out current scene and generate dialogue text
        scene = GameManager.Instance.GetCurrentScene();
        dialogueCanvas = GameObject.Find("DialogueCanvas");
        dialogueCount = 0;
        CreateDialogue();
        myText = GetComponent<Text>();
        myText.text = "";

        // Check playerprefs to see if dialogue for this scene has played before
        // If it has, skip the dialogue, otherwise play the dialogue
        string inttoget = (scene + "Instructions");
        if (PlayerPrefs.GetInt(inttoget) == 1)
        {
            SkipDialogue();
        }
        else
        {
            ForwardDialogue();
        }
    }

    // Function to enter text gradually, rather than instantly
    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            myText.text += letter;
            if (sound)
                GetComponent<AudioSource>().PlayOneShot(sound);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }

    public void SkipDialogue()
    {
        dialogueCanvas.SetActive(false);
    }

    public void ForwardDialogue()
    {
        // Check current scene and pick the right dialogue for it
        // If the dialogue for the current scene is over, call function to disable dialogue canvas
        switch (scene)
        {
            case "MasterMason":
                if (dialogueCount <= 2)
                {
                    myText.text = "";
                    message = messages[dialogueCount];
                    dialogueCount++;
                    StopAllCoroutines();
                    StartCoroutine(TypeText());
                }
                else
                {
                    string inttoset = "MasterMasonInstructions";
                    PlayerPrefs.SetInt(inttoset, 1);
                    SkipDialogue();
                }
                break;
        }
    }

    // Create array with dialogue messages
    // Keep messages at 230 or less characters
    public void CreateDialogue()
    {
        messages = new List<string>
        {
            "Test 1 hallo ik ben Heinrich",
            "Test 2",
            "Test 3",
            "Gefeliciteerd!"
        };
    }
}