using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxProgressScript : MonoBehaviour
{
    [Header("Attributes")]
    public bool mustBeActive = false;
    public int artifactId;

    [Header("Member")]
    public GameObject otherBox;

    GameManager meneger = null;


    Vector3 firstPos;
    Vector3 secondPos;

    // Start is called before the first frame update
    void Start()
    {
        meneger = GameManager.Instance;
        firstPos = otherBox.transform.position;
        secondPos = transform.position;
        if (meneger.GetArtifactValue(artifactId) == mustBeActive) {
            transform.position = firstPos;
        } else {
            transform.position = secondPos;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() {

    }
}
