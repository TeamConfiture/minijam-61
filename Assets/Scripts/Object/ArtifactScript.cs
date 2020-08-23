using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactScript : MonoBehaviour
{
    [Header("Attributes")]
    public int artifactId;
    public string scene;
    public GameObject fond;
    public bool transitionning = false;

    GameManager meneger = null;

    // Start is called before the first frame update
    void Start()
    {
        meneger = GameManager.Instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Manages whether the character is on the groud or not
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player" && !transitionning) {
            transitionning = true;
            StartCoroutine(changeScene());
            transitionning = false;
        }
    }

    IEnumerator changeScene()
    {
        meneger.GetArtifact(artifactId);
        if (fond != null) {
            fond.SetActive(true);

            yield return new WaitForSeconds(4);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        if (fond != null) {
            fond.SetActive(false);
        }
    }
}