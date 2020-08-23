using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Game Objects")]
    public Rigidbody2D rb;

    [Header("Multipliers")]
    public float moveMultiplier = 7f;
    public float jumpVelocity = 5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Attributes")]
    public int maxJumpNumber = 1;
    public bool isAlive = true;

	AudioSource audioSource;
    Animator animator;
    bool jumpRequest;
    int jumpNb;

    GameManager meneger = null;

    bool isPressedFire2 = false;
    Rigidbody2D rbFeet;
    bool onPlant;
	
    // Start is called before the first frame update
    void Start()
    {
        if(rb==null)
            rb = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
        // timer = changeTime;
        animator = GetComponent<Animator>();
        jumpRequest = false;
        jumpNb = 0;
        rbFeet = transform.GetChild(0).GetComponent<Rigidbody2D>();

        meneger = GameManager.Instance;
        onPlant = false;
    }

    private void Update() {
        if ((rb.velocity.y < 0.01f) && (rb.velocity.y > -0.01f)) {
            animator.SetFloat("SpeedY", 0.0f);
        } else if (rb.velocity.y > 0) {
            animator.SetFloat("SpeedY", 1.0f);
        } else {
            animator.SetFloat("SpeedY", -1.0f);
        }
        if ((Input.GetAxis("Horizontal") < 0.01f) && (Input.GetAxis("Horizontal") > -0.01f)) {
            animator.SetFloat("SpeedX", 0.0f);
        } else if (Input.GetAxis("Horizontal") > 0) {
            animator.SetFloat("SpeedX", 1.0f);
        } else {
            animator.SetFloat("SpeedX", -1.0f);
        }

        if (Input.GetButtonDown ("Jump") && jumpNb < maxJumpNumber)
        {
            jumpRequest = true;
            jumpNb++;
        }
        if (!isPressedFire2) {
            if (Input.GetButton("Fire2")) {
                isPressedFire2 = true;
                meneger.blocPosition = !meneger.blocPosition;
                // Debug.Log("Fire !");
            }
        } else {
            if (!Input.GetButton("Fire2")) {
                isPressedFire2 = false;
                // Debug.Log("End");
            }
        }
    }

    // Called every physics frame
    private void FixedUpdate()
    {
        if (jumpRequest) //Jump impulsion
        {
            rb.AddForce(Vector2.up * jumpVelocity * (rb.velocity.y < 0 ? 2 : 1), ForceMode2D.Impulse);
            jumpRequest = false;
        }
        if (!onPlant)
        {
            if (rb.velocity.y < 0) // Falling down
            {
                rb.gravityScale = fallMultiplier;
            }
            else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump")) // Jump gradient
            {
                rb.gravityScale = lowJumpMultiplier;
            }
            else // Reset gravity
            {
                rb.gravityScale = 1f;
            }
        }
        else
        {
            rb.gravityScale = 0f;
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), onPlant ? Input.GetAxis("Vertical") : 0f, 0f);
        transform.position += movement * Time.deltaTime * moveMultiplier;
        //float tileNumber = Mathf.FloorToInt(transform.position.x);
        //Debug.Log(tileNumber);
    }
	
    void Death() {
        if (isAlive) {
            isAlive = false;
            Debug.Log("Dead !");
			audioSource.Play();
        }
    }

    // Manages whether the character is on the groud or not
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.tag == "Spike") {
			this.Death();
		}
        if (collision.tag == "Plant")
        {
            onPlant = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            onPlant = false;
        }
    }

    public void FeetCollision()
    {
        jumpNb = 0;
    }
}
