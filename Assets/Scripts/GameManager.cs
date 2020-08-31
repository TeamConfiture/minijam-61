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

    public GameObject respawnLocation;
    public GameObject respawnCamera;

    public delegate void ResetAction();
    public static event ResetAction ResetPrefabs;

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

    public void ResetGame()
    {
        Interacting = false;
        blocPosition = false;
        obtainedStatus[0]=false;
        obtainedStatus[1]=false;
        obtainedStatus[2]=false;
    }

    public void GetArtifact(int artifactId) {
        Debug.Log("Obtained Artifact !");
        if (artifactId < 1 || artifactId > 3) {
            Debug.Log("Wrong ID !!!");
        } else {
            obtainedStatus[artifactId-1] = true;
        }
    }

    public bool GetArtifactValue(int artifactId) {
        if (artifactId < 1 || artifactId > 3)
            return false;
        return obtainedStatus[artifactId-1];
    }

    public void TriggerPrefabsReset()
    {
        ResetPrefabs();
    }
}
