using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    private float letterPause = 0.03f;
    public List<GameObject> Imagery;

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

        switch (scene)
        {
            case "MasterMason":
                dialogueCount = 0;
                break;

            case "Carpenter":
                dialogueCount = 6;
                break;
            case "Story":
                dialogueCount = 9;
                break;

        }

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
        if (scene == "Story")
        {
            GameManager.Instance.ChangeScene("Map");
        }

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

                ForwardText(4, "MasterMasonInstructions");
                break;

            case "Carpenter":

                ForwardText(7, "CarpenterInstructions");
                break;

            case "Story":

                if (!crRunning)
                {
                    ChangeImagery();
                }
                ForwardText(29, "StorySeen");
                break;
        }
    }

    public void FinishGame()
    {
        switch (scene)
        {
            case "MasterMason":
                dialogueCount = 5;
                PlayerPrefs.SetInt("MasterMasonCompleted", 1);
                break;

            case "Carpenter":
                dialogueCount = 8;
                PlayerPrefs.SetInt("CarpenterCompleted", 1);
                break;
        
        }

        gameFinished = true;
        dialogueCanvas.SetActive(true);
        myText.text = "";
        message = messages[dialogueCount];
        StartCoroutine(TypeText());
    }

    private void ForwardText(int dialogueEnd, string instructionsName)
    {
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
        else if (dialogueCount <= dialogueEnd)
        {
            myText.text = "";
            message = messages[dialogueCount];
            dialogueCount++;
            StopAllCoroutines();
            StartCoroutine(TypeText());
        }
        else
        {
            PlayerPrefs.SetInt(instructionsName, 1);
            SkipDialogue();
        }
    }

    // Create array with dialogue messages
    // Keep messages at 230 or less characters
    public void CreateDialogue()
    {
        messages = new List<string>
        {
            // Master mason dialogue (0-5)
            "Hoi, fijn dat jij er bent. Ik hoorde dat je op zoek was naar een raar stuk metaal. Die mag je ook hebben, maar eerst zou ik het waarderen als jij mij helpt met bouwen van de kerk.",
            "Ik ben bouwmeester Heinrich. Als bouwmeester mocht ik de kerk ontwerpen en de plannen maken voor het bouwen. Ik was niet altijd een bouwmeester. Mijn eerste vak was steenhouwen. Dat is vormen uit een stuk steen hakken.",
            "Toen werd ik een van de beste steenhouwers en mocht ik de leerling worden van een bouwmeester. Die heeft mij geleerd hoe ik plannen moest maken en hoe ik het plan moest uitvoeren om een kerk te bouwen.",
            "Vandaag ben ik bezig met het maken van een kruisribgewelf. Moeilijk woord, he? Kijk naar boven in de kerk, daar kun je een kruisribgewelf zien. Je kan zien hoe de stenen ribben een kruising maken.",
            "Ben je klaar om mij te helpen?",
            "Hoe fantastisch! Dat kruisribgewelf ziet er perfect uit. Bedankt voor je hulp.",
            // Carpenter dialogue (6-8)
            "Hallo. Ik ben timmervrouw Philipa. Jij bent degene die op zoek is naar een raar stuk zwaar metaal, toch? Ik heb nooit zoiets gezien hoor! Ik ben wel nieuwsgierig naar wat het is, maar je mag hem zeker terug hebben.",
            "Zou je iets voor mij eerst kunnen doen? Wij zijn bezig met het bouwen van de toren, maar onze tredmolen is kapot gegaan.",
            "Geweldig! Je hebt de tredmolen gemaakt. Dank je wel!",
            // Game Introduction (9-29)
            "Hoi! Ik ben Bert Dijkink de stadshistoricus. Ik ben iemand die veel afweet van de geschiedenis van Zwolle.",
            // panel 2
            "Ik wil je over een schat vertellen die je onder de Grote Kerk kan vinden.",
            // panel 3
            "Achter het koorhek ligt er een grafsteen die de ingang is naar een crypte. In die crypte kun je allemaal onderdelen van de oude romaanse kerk vinden die hier eerst stond.",
            "In die crypte vind je een deurtje. Als je door dat deurtje gaat vind je de schat van Zwolle!",
            // panel 4
            "Speler: Oh wauw, er is echt een deur! Maar wat is dat blauwe licht?",
            // panel 5
            "Speler: Wat is dat? Ziet eruit als een rare machine. Waar is de schat? Ligt die misschien in het machine?",
            // panel 6
            "Speler: Huh?",
            "Walkie-talkie Henk: Hoi! Zou je ons kunnen helpen?",
            "Speler: Uhh… ja? Wie zijn jullie? Waar zijn jullie?",
            "WT Henk: Ik ben Henk…",
            "WT Karlijn: ...En ik ben Karlijn.",
            "WT Henk en Karlijn: Wij zitten vast in de middeleeuwen!",
            "Speler: Hoe is dat mogelijk? Ik dacht dat er een schat was.",
            "WT Henk: Dit is de schat! De schat is een tijdmachine! We hebben het gebruikt om terug in de tijd te gaan om de geschiedenis van Zwolle te beleven.",
            "WT Henk: Wij hebben de tijdmachine gebruikt, maar helaas is onze controlepaneel kapotgegaan.",
            "WT Karlijn: Zie je die lege plek op de rechter tafel? Daar stond het controlepaneel, maar die is in 4 stukken gebroken toen wij terug naar de middeleeuwen gingen om de bouw van de Grote Kerk te beleven.",
            "Speler: Hoe kan ik helpen?",
            "WT Henk: Vier ambachtslieden hebben elk een stuk van het controlepaneel. Vergeet niet de walkie talkie mee te nemen.",
            "WT Henk: Hij is speciaal. Met behulp van de walkie talkie kan je terug in de middeleeuwen kijken en met de ambachtslieden praten.",
            "WT Karlijn: En dan moet je tijdstukken nog scannen! Zo kunnen wij de belangrijke momenten in de geschiedenis van de Grote Kerk ervaren.",
            "Speler: Super!",
            //

        };
    }
    /// <summary>
    /// changest the imagery in a scene to acompainy the text
    /// </summary>
    /// <param name="count"> Dialogcount</param>
    public void ChangeImagery()
    {
        switch (scene)
        {
            case "Story":
                switch (dialogueCount)
                {
                    case 10:
                        Imagery[0].SetActive(true);
                        break;

                    case 12:
                        Imagery[1].SetActive(true);
                        break;

                    case 13:
                        Imagery[2].SetActive(true);
                        break;

                    case 14:
                        Imagery[3].SetActive(true);
                        break;

                    case 15:
                        Imagery[4].SetActive(true);
                        break;
                }
                break;
        }
    }
}