using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    public float letterPause = 0.1f;
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
                ForwardText(28, "StorySeen");
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
            // Game Introduction (9-28)
            "Hoi! Ik ben Bert Dijkink. Ik ben een stadshistoricus. Historicus betekent dat ik iemand ben die het geschiedenis onderzoekt.",
            // panel 2
            "Ik ga je over een schat vertellen die je onder de Grote Kerk kan vinden.",
            // panel 3
            "Achter de koorhek is er een grafsteen die de ingang is naar een crypte. In die crypte kun je allemaal onderdelen van de oude romaanse kerk vinden die eerst hier stond. De Grote Kerk is om die kleine kerk gebouwd.",
            "In de crypte vind je een deurtje. Als je door de deurtje gaat vind je de schat van Zwolle!",
            // panel 4
            "Oh wow, er is echt een deur! Maar wat is dat blauw licht?",
            // panel 5
            "Woah! Wat is dat? Ziet eruit als een raar machine. Waar is de schat? Is het misschien in die machine?",
            // panel 6
            "Huh?",
            "Hoi! Zou je ik en mijn zus kunnen helpen?",
            "Uhh… ja? Wie zijn jullie? Waar zijn jullie?",
            "Ik ben Henk…",
            "...En ik ben Karlijn.",
            "Wij zitten vast in de middeleeuwen!",
            "Hoe is dat mogelijk? Ik dacht dat er een schat was.",
            "Dit is het schat! Het schat is een tijdmachine die je kan gebruiken om de geschiedenis van Zwolle mee te maken. Mijn zus en ik hebben het gebruikt, maar helaas is onze control panel kapot gegaan.",
            "Zie je die lege plek op de tafel? Daar stond de control panel, maar die is in 4 stukken kapot gegaan toen wij terug naar de middeleeuwen ging om het bouw van de Grote Kerk mee te maken.",
            "Hoe kan ik helpen?",
            "Vier vakmannen hebben elk een stuk van de control panel. Neem de walkie talkie mee. Het is speciaal. Met behulp van de walkie talkie kun je met je apparaat terug in de middeleeuwen kijken en met de vakmannen praten.",
            "En dan moet je geschiedenispunten scannen! Zo krijgen wij de jaartallen van de belangrijke momenten in de geschiedenis van Grote Kerk.",
            "En vergeet niet de walkie talkie mee te nemen. Het is niet alleen om terug in de tijd te kijken, maar ook om in contact met ons te blijven. We kunnen jou af en toe helpen als het nodig is.",
            "Goed!"
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