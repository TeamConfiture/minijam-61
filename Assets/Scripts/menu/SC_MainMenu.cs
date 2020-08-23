using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;

    public AudioSource soundEffect;
    // Start is called before the first frame update
    public void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton(string scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        soundEffect.Play();
    }
    public void CreditsButton() {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        soundEffect.Play();
    }
    public void MainMenuButton() {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }
    public void BackButton(){
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        soundEffect.Play();
    }
    public void QuitButton() {
        Application.Quit();
    }
    
}
