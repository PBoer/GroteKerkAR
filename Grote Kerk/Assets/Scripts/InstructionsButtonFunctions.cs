using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsButtonFunctions : MonoBehaviour {

    public List<GameObject> contentPanels;
    public List<GameObject> contentButtons;

    /// <summary>
    /// positions of panels in the list
    /// </summary>
    private const int GamePanel = 0;
    private const int MasterMasonPanel = 1;
    private const int StoneCutterPanel = 2;
    private const int GlassWorkerPanel = 3;
    private const int CarpenterPanel = 4;

    // Use this for initialization
    void Start() {
        DisablePanels();

        // Check PlayerPrefs to see which instructions the player is allowed to see,
        // then activate the tabs for those instructions
        foreach (GameObject contentButton in contentButtons)
        {
            switch (PlayerPrefs.GetInt(contentButton.name))
            {
                case 0:
                    contentButton.SetActive(false);
                    break;
                case 1:
                    contentButton.SetActive(true);
                    break;
                default:
                    contentButton.SetActive(false);
                    break;
            }
        }
        GameInstructions();

    }

    // Update is called once per frame
    void Update() {

    }

    /// <summary>
    /// Function to disable all panels
    /// </summary>
    public void DisablePanels()
    {
        foreach (GameObject contentPanel in contentPanels)
        {
            contentPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Function to return to previous scene
    /// </summary>
    public void Back()
    {
        // If previous scene was story, move on to map scene
        if (GameManager.Instance.getPreviousScene() == "Story")
        {
            GameManager.Instance.ChangeScene("Map");
        }
        else
        {
            GameManager.Instance.GoToPreviousScene();
        }
    }

    /// <summary>
    /// Function to show panel containing instructions for the overall game
    /// </summary>
    public void GameInstructions()
    {
        DisablePanels();
        contentPanels[GamePanel].SetActive(true);
    }

    /// <summary>
    /// Function to show panel containing instructions for master mason minigame
    /// </summary>
    public void MasterMasonInstructions()
    {
        DisablePanels();
        contentPanels[MasterMasonPanel].SetActive(true);
    }

    /// <summary>
    /// Function to show panel containing instructions for stone cutter minigame
    /// </summary>
    public void StoneCutterInstructions()
    {
        DisablePanels();
        contentPanels[StoneCutterPanel].SetActive(true);
    }

    /// <summary>
    /// Function to show panel containing instructions for glass worker minigame
    /// </summary>
    public void GlassWorkerInstructions()
    {
        DisablePanels();
        contentPanels[GlassWorkerPanel].SetActive(true);
    }

    /// <summary>
    /// Function to show panel containing instructions for carpenter minigame
    /// </summary>
    public void CarpenterInstructions()
    {
        DisablePanels();
        contentPanels[CarpenterPanel].SetActive(true);

    }
}
