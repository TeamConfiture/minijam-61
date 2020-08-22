using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalk : MonoBehaviour
{

	[Header("Roaming Location")]
	public float roamingDistance;
	public float movementVelocity;

	float startX;
	bool normalDirection = true;

    // Start is called before the first frame update
    void Start()
    {
    	startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
    	transform.Translate(movementVelocity * Vector3.right * Time.deltaTime);
    	if (transform.position.x > (startX + roamingDistance) && normalDirection) {
    		normalDirection = false;
    		transform.Rotate(0.0f, 180.0f, 0.0f);
    	}
    	if (transform.position.x < startX && !normalDirection) {
    		normalDirection = true;
    		transform.Rotate(0.0f, 180.0f, 0.0f);
    	}
    }
}
