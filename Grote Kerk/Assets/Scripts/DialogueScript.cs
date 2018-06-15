using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    private float letterPause = 0.03f;
    public List<GameObject> Imagery;

    private string instructionsName;
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
        CreateDialogue();

        // Based on which scene player is in, set dialogueCount to the proper number
        switch (scene)
        {
            case "MasterMason":
                dialogueCount = 0;
                break;

            case "Carpenter":
                dialogueCount = 7;
                break;
            case "Story":
                dialogueCount = 16;
                break;

        }

        // Find text component and empty it
        myText = GetComponent<Text>();
        myText.text = "";

        // Check playerprefs to see if dialogue for this scene has played before
        // If it has, skip the dialogue, otherwise play the dialogue
        instructionsName = (scene + "Instructions");
        if (PlayerPrefs.GetInt(instructionsName) == 1)
        {
            SkipDialogue();
        }
        else
        {
            if(scene == "Story")
            {
                instructionsName = "StorySeen";
            }
            ForwardDialogue();
        }
        
    }

    // Function to enter text gradually, rather than instantly
    IEnumerator TypeText()
    {
        crRunning = true;
        foreach (char letter in message.ToCharArray())
        {
            myText.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        crRunning = false;
    }


    /// <summary>
    /// Function to skip dialogue
    /// </summary>
    public void SkipDialogue()
    {
        // Check if player has seen the story before, if so, go to the map scene
        // if not, go to the instructions screen
        if (scene == "Story")
        {
            if (PlayerPrefs.GetInt("StorySeen") == 1)
            {
                GameManager.Instance.ChangeScene("Map");
            }
            else
            {
                GameManager.Instance.ChangeScene("Instructions");
            }
        }

        // Check if current minigame has been completed, if so, go back to the main game scene
        // If not, deactivate dialogue canvas to start the game,
        // and set int in playerprefs so next time the game knows the player has seen this dialogue before
        if(gameFinished)
        {
            GameManager.Instance.ChangeScene("MainGame");
        }
        else
        {
            PlayerPrefs.SetInt(instructionsName, 1);
            dialogueCanvas.SetActive(false);
        }
    }

    /// <summary>
    /// Function to progress the dialogue
    /// </summary>
    public void ForwardDialogue()
    {
        // Check if text is still running. If it is, stop running it and show it instantly.
        if (crRunning)
        {
            StopAllCoroutines();
            myText.text = message;
            crRunning = false;
        }
        else
        {
            // Check current scene and pick the right dialogue for it
            // If the dialogue for the current scene is over, call function to disable dialogue canvas
            switch (scene)
            {
                case "MasterMason":

                    ForwardText(5);
                    break;

                case "Carpenter":

                    ForwardText(14);
                    break;

                case "Story":

                    if (!crRunning)
                    {
                        ChangeImagery();
                    }
                    ForwardText(40);
                    break;
            }
        }
    }

    /// <summary>
    /// Function to show dialogue after finishing the minigame
    /// </summary>
    public void FinishGame()
    {
        // Set dialogueCount to proper number based on current scene
        switch (scene)
        {
            case "MasterMason":
                dialogueCount = 6;
                break;

            case "Carpenter":
                dialogueCount = 15;
                break;
        
        }

        // Show final dialogue and set gameFinished boolean to true
        gameFinished = true;
        dialogueCanvas.SetActive(true);
        myText.text = "";
        message = messages[dialogueCount];
        StartCoroutine(TypeText());
    }

    /// <summary>
    /// Function used in ForwardDialogue to show the next line of text
    /// </summary>
    /// <param name="dialogueEnd"></param>
    private void ForwardText(int dialogueEnd)
    {
        // If game has been finished, go back to main game scene
        if (gameFinished)
        {
            GameManager.Instance.ChangeScene("MainGame");
        }
        // If game has not been finished and player is not at the final line of dialogue yet,
        // start next line of dialogue
        else if (dialogueCount <= dialogueEnd)
        {
            myText.text = "";
            message = messages[dialogueCount];
            dialogueCount++;
            StopAllCoroutines();
            StartCoroutine(TypeText());
        }
        // If game has not been finished and player is at the final line of dialogue, call SkipDialogue to deactivate dialogue canvas
        else
        {
            SkipDialogue();
        }
    }

    /// <summary>
    /// Function to replay dialogue
    /// </summary>
    public void ReplayDialogue()
    {
        // If game has been finished, do nothing. Otherwise, reset dialogue
        if (!gameFinished)
        {
            switch (scene)
            {
                case "MasterMason":
                    dialogueCount = 0;
                    ForwardDialogue();
                    break;

                case "Carpenter":
                    dialogueCount = 7;
                    ForwardDialogue();
                    break;
                case "Story":
                    dialogueCount = 16;
                    ForwardDialogue();
                    break;
            }
        }
    }

    /// <summary>
    /// Function to go back a line in the dialogue
    /// </summary>
    public void BackDialogue()
    {
        // If game has been finished, do nothing. Otherwise, go back a line
        // If dialogue is at the start, replay current line
        if (!gameFinished)
        {
            switch (scene)
            {
                case "MasterMason":
                    if (dialogueCount > 0)
                    {
                        dialogueCount -= 2;
                        BackText(0);
                    }
                    else
                    {
                        BackText(0);
                    }
                    break;

                case "Carpenter":
                    if (dialogueCount > 7)
                    {
                        dialogueCount -= 2;
                        BackText(7);
                    }
                    else
                    {
                        BackText(7);
                    }
                    break;

                case "Story":
                    if (dialogueCount > 16)
                    {
                        dialogueCount -= 2;
                        ChangeImagery();
                        BackText(16);
                    }
                    else
                    {
                        BackText(16);    
                        ChangeImagery();
                        
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// Function used in BackDialogue to show the previous line of text
    /// </summary>
    /// <param name="dialogueStart"></param>
    private void BackText(int dialogueStart)
    {
        if(dialogueCount < dialogueStart)
        {
            dialogueCount++;
        }
        myText.text = "";
        message = messages[dialogueCount];
        StopAllCoroutines();
        StartCoroutine(TypeText());
        dialogueCount++;
    }

    /// <summary>
    /// Function to create array with dialogue
    /// Lines must be 160 characters or less to fit in the text fields
    /// </summary>
    public void CreateDialogue()
    {
        messages = new List<string>
        {
            // Master mason dialogue (0-6)
            "Hoi, goed dat jij er bent.",
            "Ik hoorde dat je op zoek was naar een raar stuk metaal. Die mag je hebben, maar dan waardeer ik het wel als jij mij helpt met bouwen van de kerk.",
            "Ik ben bouwmeester Heinrich. Als bouwmeester mocht ik de kerk ontwerpen en de plannen maken voor het bouwen.",
            "Vandaag ben ik bezig met het maken van een kruisribgewelf. Moeilijk woord, he?",
            "Kijk naar boven in de kerk, daar kun je een kruisribgewelf zien. Je kan zien hoe de stenen ribben een kruising maken.",
            "Ben je klaar om mij te helpen?",
            "Wat fantastisch! Dat kruisribgewelf ziet er perfect uit. Bedankt voor je hulp.",
            // Carpenter dialogue (7-15)
            "Hallo, ik ben timmervrouw Philipa. Jij bent degene die op zoek is naar een raar stuk zwaar metaal, toch? Ik heb nooit zoiets gezien hoor!",
            "Ik ben wel nieuwsgierig naar wat het is, maar je mag hem zeker terug hebben. Zou je iets voor mij eerst kunnen doen? Wij zijn bezig met het bouwen van de toren.",
            "Het gaat de hoogste toren van Nederland worden! Helaas is onze tredmolen kapot gegaan. Nu kunnen wij niet meer bakstenen naar boven hijsen.",
            "Ik heb nieuwe onderdelen hier ergens liggen, maar ik herinner mij niet zo goed meer waar die te vinden zijn.",
            "Zou jij de onderdelen voor mij kunnen zoeken en naar mij terugbrengen?",
            "Een tredmolen is een molen die gebruik maakt van de spierkracht van mensen of dieren om in beweging te komen. De tredmolen heeft een groot wiel.",
            "Bij een tredmolen is het wiel zo groot dat er een of meerdere personen in het wiel kunnen lopen.",
            "Kun je je dan voorstellen hoe groot het wiel is? En hoe groot de molen zelf is!",
            "Geweldig! Met deze nieuwe tredmolen kunnen we de toren verder bouwen.",

            // Game Introduction (16-40)
            "Bert: Hoi! Ik ben Bert Dijkink de stadshistoricus. Ik ben iemand die veel afweet van de geschiedenis van Zwolle.",
            // panel 2 line:17
            "Bert: Ik wil je over een schat vertellen die je onder de Grote Kerk kan vinden.",
            // panel 3 line:18
            "Bert: Achter het koorhek ligt een grafsteen die de ingang is naar een crypte. Daaronder kun je onderdelen van de oude Romaanse kerk vinden die hier eerst stond.",
            "Bert: In die crypte vind je ook een deurtje. Als je door dat deurtje gaat, vind je de schat van Zwolle!",
            // panel 4 line:20
            "Speler: Oh wauw, er is echt een deur! Maar wat is dat blauwe licht?",
            // panel 5 line:21
            "Speler: Wat is dat? Ziet eruit als een rare machine. Waar is de schat? Ligt die misschien in de machine?",
            // panel 6 line:22
            "Speler: Huh?",
            // line:23
            "Henk: Hoi! Zou je ons kunnen helpen?",
            // line:24
            "Speler: Uhh… ja? Wie zijn jullie? Waar zijn jullie?",
            // line:25
            "Henk: Ik ben Henk…",
            "Karlijn: ...En ik ben Karlijn.",
            "Henk en Karlijn: Wij zitten vast in de middeleeuwen!",
            "Henk: De schat is een tijdmachine! We hebben het gebruikt om terug in de tijd te gaan en de geschiedenis van de Grote Kerk te beleven.",
            "Henk: Helaas is onze controlepaneel kapot gegaan en heeft de tijdmachine geen energie meer om door de tijd heen te kunnen reizen.",
            "Karlijn: Zie je die lege plek op de rechter tafel? Daar stond het controlepaneel, maar die is in vier stukken gebroken.",
            "Karlijn: Zou je ons kunnen helpen om terug naar het heden te komen?",
            // line:33
            "Speler: Hoe kan ik helpen?"
            //

        };
    }
    /// <summary>
    /// changest the imagery in a scene to acompainy the text
    /// </summary>
    /// <param name="count"> dialogueCount</param>
    public void ChangeImagery()
    {
        switch (scene)
        {
            case "Story":
                switch (dialogueCount)
                {
                    case 16:
                        Imagery[0].SetActive(true);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(false);
                        Imagery[6].SetActive(false);
                        Imagery[7].SetActive(false);
                        break;
                    case 17:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(true);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(false);
                        Imagery[6].SetActive(false);
                        Imagery[7].SetActive(false);
                        break;

                    case 18:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(true);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(false);
                        Imagery[6].SetActive(false);
                        Imagery[7].SetActive(false);
                        break;
                    case 19:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(true);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(false);
                        Imagery[6].SetActive(false);
                        Imagery[7].SetActive(false);
                        break;

                    case 20:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(true);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(false);
                        Imagery[6].SetActive(true);
                        Imagery[7].SetActive(false);
                        break;

                    case 21:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(true);
                        Imagery[5].SetActive(false);
                        Imagery[6].SetActive(true);
                        Imagery[7].SetActive(false);
                        break;

                    case 22:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(true);
                        Imagery[6].SetActive(true);
                        Imagery[7].SetActive(false);
                        break;
                    case 23:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(true);
                        Imagery[6].SetActive(false);
                        Imagery[7].SetActive(true);
                        break;
                    case 24:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(true);
                        Imagery[6].SetActive(true);
                        Imagery[7].SetActive(false);
                        break;
                    case 25:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(true);
                        Imagery[6].SetActive(false);
                        Imagery[7].SetActive(true);
                        break;
                    case 32:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(true);
                        Imagery[6].SetActive(false);
                        Imagery[7].SetActive(true);
                        break;
                    case 33:
                        Imagery[0].SetActive(false);
                        Imagery[1].SetActive(false);
                        Imagery[2].SetActive(false);
                        Imagery[3].SetActive(false);
                        Imagery[4].SetActive(false);
                        Imagery[5].SetActive(true);
                        Imagery[6].SetActive(true);
                        Imagery[7].SetActive(false);
                        break;
                }
                break;
        }
    }
}