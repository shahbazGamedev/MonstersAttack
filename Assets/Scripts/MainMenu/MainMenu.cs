using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    //Public references
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject playPanel;

    void Awake()
    {
        //Initialize components
        mainPanel = GameObject.Find("MainPanel");
        optionsPanel = GameObject.Find("OptionsPanel");
        playPanel = GameObject.Find("PlayPanel");

        //Dissable all the panels
        DissableAllPanels();
        //Enable the panel we need show first
        mainPanel.SetActive(true);
    }

    //Function to show the play menu
	public void Play()
    {
        DissableAllPanels();
        playPanel.SetActive(true);
    }

    //Function to show the options menu
    public void Options()
    {
        DissableAllPanels();
        optionsPanel.SetActive(true);
    }

    //Function to exit the application
    public void Quit()
    {
        Application.Quit();
    }

    //Function to dissable all the panels
    public void DissableAllPanels()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        playPanel.SetActive(false);
    }
}
