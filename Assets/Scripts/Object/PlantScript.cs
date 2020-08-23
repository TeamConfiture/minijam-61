using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{

    private int growState;
    private GameObject currentGrowState;
    private GameObject nextGrowState;
    private bool canGrow;
    private bool hasGrown;

    // Start is called before the first frame update
    void Start()
    {
        growState = 0;
        currentGrowState = transform.GetChild(growState).gameObject;
        nextGrowState = transform.GetChild(growState + 1).gameObject;
        canGrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGrown)
        {
            currentGrowState.SetActive(false);
            nextGrowState.SetActive(true);
            currentGrowState = transform.GetChild(growState).gameObject;
            if (growState < 3)
            {
                nextGrowState = transform.GetChild(growState + 1).gameObject;
            } else
            {
                canGrow = false;
            }
            hasGrown = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rain")
        {
            if (canGrow)
            {
                canGrow = false;
                StartCoroutine("GrowNext");
            }
        }
    }

    IEnumerator GrowNext()
    {
        yield return new WaitForSeconds(1.5f);
        growState++;
        canGrow = true;
        hasGrown = true;
    }
}
