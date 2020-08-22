using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    bool oldPos = false;
    GameManager meneger = null;

    [Header("Attributes")]
    public GameObject otherBox;


    // Start is called before the first frame update
    void Start()
    {
        meneger = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldPos != meneger.blocPosition) {
            oldPos = meneger.blocPosition;
            var temposition = transform.position;
            transform.position = otherBox.transform.position;
            otherBox.transform.position = temposition;
        }
    }
}
