using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Attributes")]
    public bool blocPosition = false;
    [Header("Game Status")]
    public bool[] obtainedStatus = new bool[3] {false, false, false};



    public static GameManager Instance;

    public bool Interacting = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void GetArtifact(int artifactId) {
        Debug.Log("Obtained Artifact !");
        if (artifactId < 1 || artifactId > 3) {
            Debug.Log("Wrong ID !!!");
        } else {
            obtainedStatus[artifactId] = true;
        }
    }
}
