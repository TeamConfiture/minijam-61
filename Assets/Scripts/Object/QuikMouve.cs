using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuikMouve : MonoBehaviour
{

    [Header("Attribute")]
    public GameObject destination;
	
    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log(destination.transform.position);
			collision.transform.position = destination.transform.position;
			collision.attachedRigidbody.velocity = Vector2.zero;
        }
    }
}
