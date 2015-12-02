using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    //Public references
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject skillsPanel;

    void Awake()
    {
        //Initialize components
        mainPanel = GameObject.Find("MainPanel");
        optionsPanel = GameObject.Find("OptionsPanel");
        skillsPanel = GameObject.Find("SkillsPanel");

        //Dissable all the panels
        DissableAllPanels();
        //Enable the panel we need show first
        mainPanel.SetActive(true);
    }

    //Function to show the main menu
    public void Main()
    {
        DissableAllPanels();
        mainPanel.SetActive(true);
    }

    //Function to show the play menu
	public void Skills()
    {
        DissableAllPanels();
        skillsPanel.SetActive(true);
    }

    //Function to show the options menu
    public void Options()
    {
        DissableAllPanels();
        optionsPanel.SetActive(true);
    }

    //Function to load the scene to play
    public void PlayLevel()
    {
        Application.LoadLevel(1);
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
        skillsPanel.SetActive(false);
    }
}
