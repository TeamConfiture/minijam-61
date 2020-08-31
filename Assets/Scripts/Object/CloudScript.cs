using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    [Header("Borders")]
    public Transform borderTop;
    public Transform borderRight;
    public Transform borderBottom;
    public Transform borderLeft;

    private bool isRaining;
    private GameObject rain;
    private Vector3 mousePosition;
    private int line = -1;
    private int numberOfLines = 10;
    // Start is called before the first frame update
    void Start()
    {
        isRaining = false;
        rain = transform.GetChild(0).gameObject;
        rain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.y < borderTop.position.y
            && mousePosition.y > borderBottom.position.y
            && mousePosition.x < borderRight.position.x
            && mousePosition.x > borderLeft.position.x
        )
        {
            transform.position = Vector2.Lerp(transform.position, mousePosition, 0.1f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            line++;
        }

        isRaining = false;
        if (Input.GetButton("Fire1") && line >= numberOfLines)
        {
            isRaining = true;
        }
        rain.SetActive(isRaining);
    }
}
