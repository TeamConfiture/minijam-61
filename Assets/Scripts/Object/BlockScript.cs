using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [Header("Attributes")]
    public bool isActive = false;
    bool oldActive = false;

    [Header("Member")]
    public GameObject otherBox;
    public TorchScript[] myGameObjects;


    bool moving = false;
    Vector3 firstPos;
    Vector3 secondPos;
    Vector3 futureMove;
    float endOfMoveTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        firstPos = otherBox.transform.position;
        secondPos = transform.position;
        futureMove = firstPos - secondPos;
    }

    // Update is called once per frame
    void Update()
    {
        bool total = true;
        foreach (TorchScript elem in myGameObjects) {
            total &= elem.isActive;
        }
        isActive = total;
        if (!moving) {
            if (isActive != oldActive) {
                endOfMoveTime = Time.time + 1;
                oldActive = isActive;
                futureMove = secondPos - firstPos;
                var temp = firstPos;
                firstPos = secondPos;
                secondPos = temp;
                moving = true;
            }
        }
    }

    private void FixedUpdate() {
        if (moving) {
            transform.position = secondPos + (futureMove*Mathf.Max(0,endOfMoveTime - Time.time));

            if (endOfMoveTime - Time.time <= 0) {
                moving = false;
            }
        }
    }
}
