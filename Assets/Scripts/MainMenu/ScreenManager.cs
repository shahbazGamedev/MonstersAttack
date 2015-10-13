using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ScreenManager : MonoBehaviour {

	private GameObject mainMenu, playMenu, shopMenu, archivementsMenu, skillsMenu;
	private GameObject previousMenu, activeMenu;

	void Awake(){
		mainMenu = GameObject.Find("MainMenu");
		playMenu = GameObject.Find("PlayMenu");
		shopMenu = GameObject.Find("ShopMenu");
		archivementsMenu = GameObject.Find("ArchivementsMenu");
		skillsMenu = GameObject.Find("SkillsMenu");
	}

	void Start(){
		mainMenu.SetActive(true);
		playMenu.SetActive(false);
		shopMenu.SetActive(false);
		archivementsMenu.SetActive(false);
		skillsMenu.SetActive(false);
		previousMenu = mainMenu;
		activeMenu = mainMenu;
        QualitySettings.antiAliasing = 0;

	}

	public void Switcher(int selector){
		if(selector != 5){previousMenu = activeMenu;}
		switch(selector){
			case 0: // Main Menu
			previousMenu.SetActive(false);
			mainMenu.SetActive(true);
			activeMenu = mainMenu;

			break;
			case 1: // Play Menu
			previousMenu.SetActive(false);
			playMenu.SetActive(true);
			activeMenu = playMenu;

			break;
			case 2: // Shop Menu
			previousMenu.SetActive(false);
			shopMenu.SetActive(true);
			activeMenu = shopMenu;

			break;
			case 3: // Archivements Menu
			previousMenu.SetActive(false);
			archivementsMenu.SetActive(true);
			activeMenu = archivementsMenu;

			break;
			case 4: //Skills Menu
			previousMenu.SetActive(false);
			skillsMenu.SetActive(true);
			activeMenu = skillsMenu;

			break;
			case 5: //Back Button
			if(previousMenu != activeMenu){
				previousMenu.SetActive(true);
				activeMenu.SetActive(false);
				activeMenu = previousMenu;
			}else{
				previousMenu= mainMenu;
				activeMenu.SetActive(false);
				previousMenu.SetActive(true);
				activeMenu=previousMenu;
			}
			break;
			case 6: // Quit
			Application.Quit();
			break;
			default:
			break;
		}
	}

	public void LevelLoader(string LevelName){
		Application.LoadLevel(LevelName);
	}
	
}
