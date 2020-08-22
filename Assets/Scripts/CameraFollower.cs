using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public GameObject player;
    public GameObject background;

    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 lockY;
    private Vector3 lockX;
    private float backgroundSizeX;
    private float backgroundSizeY;
    private float cameraSizeX;
    private float cameraSizeY;
    private float maxX;
    private float maxY;

    void Start()
    {

        backgroundSizeX = background.GetComponent<Renderer>().bounds.size.x / 2.0f;
        backgroundSizeY = background.GetComponent<Renderer>().bounds.size.y / 2.0f;
        //Debug.Log (backgroundSizeX);
        //Debug.Log (backgroundSizeY);
        cameraSizeY = GetComponent<Camera>().orthographicSize;
        cameraSizeX = cameraSizeY * 1.7778f;
        //Debug.Log (cameraSizeX);
        //Debug.Log (cameraSizeY);
        maxX = backgroundSizeX - cameraSizeX;
        maxY = backgroundSizeY - cameraSizeY;
        //Debug.Log (maxX);
        //Debug.Log (maxY);
    }

    void LateUpdate()
    {

        if (player.transform.position.x > maxX && player.transform.position.y > maxY)
        {//On check X et Y
            transform.position = new Vector3(maxX, maxY, offset.z);
        }
        else if (player.transform.position.x > maxX && player.transform.position.y < -maxY)
        {
            transform.position = new Vector3(maxX, -maxY, offset.z);
        }
        else if (player.transform.position.x < -maxX && player.transform.position.y > maxY)
        {
            transform.position = new Vector3(-maxX, maxY, offset.z);
        }
        else if (player.transform.position.x < -maxX && player.transform.position.y < -maxY)
        {
            transform.position = new Vector3(-maxX, -maxY, offset.z);
        }
        else if (player.transform.position.x > maxX || player.transform.position.x < -maxX)
        { //On check les X
            lockX = new Vector3(transform.position.x, player.transform.position.y, 0);
            transform.position = lockX + offset;
        }
        else if (player.transform.position.y > maxY || player.transform.position.y < -maxY)
        {//On check les Y
            lockY = new Vector3(player.transform.position.x, transform.position.y, 0);
            transform.position = lockY + offset;
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
    }
}
