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

    public void DisablePanels()
    {
        foreach (GameObject contentPanel in contentPanels)
        {
            contentPanel.SetActive(false);
        }
    }

    public void Back()
    {
        GameManager.Instance.GoToPreviousScene();
    }

    public void GameInstructions()
    {
        DisablePanels();
        contentPanels[GamePanel].SetActive(true);
    }

    public void MasterMasonInstructions()
    {
        DisablePanels();
        contentPanels[MasterMasonPanel].SetActive(true);
    }

    public void StoneCutterInstructions()
    {
        DisablePanels();
        contentPanels[StoneCutterPanel].SetActive(true);
    }

    public void GlassWorkerInstructions()
    {
        DisablePanels();
        contentPanels[GlassWorkerPanel].SetActive(true);
    }

    public void CarpenterInstructions()
    {
        DisablePanels();
        contentPanels[CarpenterPanel].SetActive(true);

    }
}
