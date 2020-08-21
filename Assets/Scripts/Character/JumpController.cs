﻿using UnityEngine;

public class JumpController : MonoBehaviour
{
    // FIXME if jump is very low, may not reset
    public bool onGround = false;

    public Vector2 jumpForce = new Vector2(0, 60f);

    private Rigidbody2D parentRb;

    // Start is called before the first frame update
    void Start()
    {
        if(parentRb == null)
            parentRb = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Called every physics frame
    private void FixedUpdate()
    {
        if(onGround && Input.GetButton("Jump"))
        {
            parentRb.AddForce(jumpForce);
        }
    }

    // Manages whether the character is on the groud or not
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }
}
