using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    public float letterPause = 0.2f;

    private string scene;
    private GameObject dialogueCanvas;
    private int dialogueCount;
    private List<string> messages;
    private string message;
    private Text myText;
    private bool crRunning;

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
        crRunning = true;
        foreach (char letter in message.ToCharArray())
        {
            //crRunning = true;
            myText.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
            //crRunning = false;
        }
        crRunning = false;
    }

    public void SkipDialogue()
    {
        if(dialogueCount == 3)
        {
            GameManager.Instance.ChangeScene("MainGame");
        }
        else
        {
            dialogueCanvas.SetActive(false);
        }
    }

    public void ForwardDialogue()
    {
        // Check current scene and pick the right dialogue for it
        // If the dialogue for the current scene is over, call function to disable dialogue canvas
        switch (scene)
        {
            case "MasterMason":
                if(dialogueCount == 3)
                {
                    GameManager.Instance.ChangeScene("MainGame");
                }
                else
                {
                    if (crRunning)
                    {
                        StopAllCoroutines();
                        myText.text = message;
                        crRunning = false;
                    }
                    else if (dialogueCount <= 2)
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
                }
                break;
        }
    }

    public void FinishGame()
    {
        dialogueCanvas.SetActive(true);
        myText.text = "";
        dialogueCount = 3;
        message = messages[dialogueCount];
        StartCoroutine(TypeText());
    }

    // Create array with dialogue messages
    // Keep messages at 230 or less characters
    public void CreateDialogue()
    {
        messages = new List<string>
        {
            "Hallo, ik ben Heinrich de bouwmeester.",
            "Ik heb je hulp nodig om deze kerk te bouwen! Richt je camera op het plaatje.",
            "Dan zie je iets wat je na moet bouwen door blokken op de juiste plek te dragen.",
            "Het is je gelukt, dank je wel!"
        };
    }
}