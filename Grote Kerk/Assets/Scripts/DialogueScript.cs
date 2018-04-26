using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    public float letterPause = 0.2f;
    public AudioClip sound;

    private GameObject dialogueCanvas;
    private int dialogueCount;
    private List<string> messages;
    private string message;
    private Text myText;

    // Use this for initialization
    void Start()
    {
        dialogueCanvas = GameObject.Find("DialogueCanvas");
        dialogueCount = 0;
        CreateDialogue();
        myText = GetComponent<Text>();
        myText.text = "";
        ForwardDialogue();
    }

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
        switch (GameManager.Instance.GetCurrentScene())
        {
            case "ArchitectGame":
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