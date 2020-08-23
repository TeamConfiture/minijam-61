using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject OptionsMenu;
    // Start is called before the first frame update
    public void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton(string scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
    public void CreditsButton() {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    public void MainMenuButton() {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }
    public void QuitButton() {
        Application.Quit();
    }
    public void OptionsButtons() {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
}
