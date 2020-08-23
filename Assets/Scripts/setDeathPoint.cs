using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDeathPoint : MonoBehaviour
{

	[Header("Location")]
	public GameObject respawnLocation;
	public GameObject respawnCamera;


    // Start is called before the first frame update
    void Start()
    {
    	GameManager.Instance.respawnCamera = respawnCamera;
    	GameManager.Instance.respawnLocation = respawnLocation;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
