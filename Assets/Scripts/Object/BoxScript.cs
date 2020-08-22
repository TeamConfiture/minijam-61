using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    bool blocStatus = false;
    bool moving = false;
    Vector3 firstPos;
    Vector3 secondPos;
    Vector3 futureMove;
    GameManager meneger = null;
    float endOfMoveTime = 0.0f;

    [Header("Attributes")]
    public GameObject otherBox;


    // Start is called before the first frame update
    void Start()
    {
        meneger = GameManager.Instance;
        firstPos = otherBox.transform.position;
        secondPos = transform.position;
        blocStatus = meneger.blocPosition;
        futureMove = firstPos - secondPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving) {
            if (blocStatus != meneger.blocPosition) {
                endOfMoveTime = Time.time + 1;
                blocStatus = meneger.blocPosition;
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
