using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuikMouve : MonoBehaviour
{

    [Header("Attribute")]
    public GameObject destination;
    public Transform nextCameraPosition;

	AudioSource audioSource;
	
	
    // Start is c alled before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void FixedUpdate()
	{
	
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
			audioSource.Play();
            Debug.Log(destination.transform.position);
			collision.transform.position = destination.transform.position;
			collision.attachedRigidbody.velocity = Vector2.zero;

            if(nextCameraPosition != null)
                Camera.main.transform.position = nextCameraPosition.position;
        }
    }
}
