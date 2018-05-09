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
    private bool gameFinished;

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
        if(gameFinished)
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

                if (crRunning)
                {
                    StopAllCoroutines();
                    myText.text = message;
                    crRunning = false;
                }
                else if (gameFinished)
                {
                    GameManager.Instance.ChangeScene("MainGame");
                }
                else if (dialogueCount <= 4)
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

    public void FinishGame()
    {
        gameFinished = true;
        dialogueCanvas.SetActive(true);
        myText.text = "";
        dialogueCount = 5;
        message = messages[dialogueCount];
        StartCoroutine(TypeText());
    }

    // Create array with dialogue messages
    // Keep messages at 230 or less characters
    public void CreateDialogue()
    {
        messages = new List<string>
        {
            "Hoi, fijn dat jij er bent. Ik hoorde dat je op zoek was naar een raar stuk metaal. Die mag je ook hebben, maar eerst zou ik het waarderen als jij mij helpt met bouwen van de kerk.",
            "Ik ben bouwmeester Heinrich. Als bouwmeester mocht ik de kerk ontwerpen en de plannen maken voor het bouwen. Ik was niet altijd een bouwmeester. Mijn eerste vak was steenhouwen. Dat is vormen uit een stuk steen hakken.",
            "Toen werd ik een van de beste steenhouwers en mocht ik de leerling worden van een bouwmeester. Die heeft mij geleerd hoe ik plannen moest maken en hoe ik het plan moest uitvoeren om een kerk te bouwen.",
            "Vandaag ben ik bezig met het maken van een kruisribgewelf. Moeilijk woord, he? Kijk naar boven in de kerk, daar kun je een kruisribgewelf zien. Je kan zien hoe de stenen ribben een kruising maken.",
            "Ben je klaar om mij te helpen?",
            "Hoe fantastisch! Dat kruisribgewelf ziet er perfect uit. Bedankt voor je hulp."
        };
    }
}