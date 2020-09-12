using UnityEngine.SceneManagement;
using UnityEngine;

public class SC_EndMenu : MonoBehaviour
{
    public string Scene = "Scenes/MainMenu";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ResetGame();
            SceneManager.LoadScene(Scene);
        }
    }
}
