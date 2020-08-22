using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactScript : MonoBehaviour
{
    [Header("Attributes")]
    public int artifactId;

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
        if (collision.tag == "Player") {
            meneger.GetArtifact(artifactId);
        }/* else {
            Debug.Log("Colliding");
            Debug.Log(collision.tag);
        }*/
    }
}
