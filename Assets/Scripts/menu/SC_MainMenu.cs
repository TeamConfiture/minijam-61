using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    // Start is called before the first frame update
    public void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("testSpikes");
    }
    public void CreditsButton() {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }
    public void MainMenuButton() {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }
    public void QuitButton() {
        Application.Quit();
    }
    // Update is called once per frame
}
