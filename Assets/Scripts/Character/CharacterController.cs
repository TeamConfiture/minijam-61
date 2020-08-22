using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Game Objects")]
    public Rigidbody2D rb;

    [Header("Multipliers")]
    public Vector2 movesMultiplier;
    public float airControl = 0.5f;

    [Header("Attributes")]
    public bool isAlive = true;

    JumpController jc;
	AudioSource audioSource;
    Animator animator;
    GameManager meneger = null;

    bool isPressedFire2 = false;
	
    // Start is called before the first frame update
    void Start()
    {
        if(rb==null)
            rb = GetComponent<Rigidbody2D>();
        jc = GetComponentInChildren<JumpController>();
		audioSource = GetComponent<AudioSource>();
        // timer = changeTime;
        animator = GetComponent<Animator>();

        meneger = GameManager.Instance;
    }

    void Update() {
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

        if (!isPressedFire2) {
            if (Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3")) {
                isPressedFire2 = true;
                meneger.blocPosition = !meneger.blocPosition;
                // Debug.Log("Fire !");
            }
        } else {
            if (!(Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3"))) {
                isPressedFire2 = false;
                // Debug.Log("End");
            }
        }
        // Debug.Log(rb.velocity);
    }

    // Called every physics frame
    private void FixedUpdate()
    {
        rb.AddForce(movesMultiplier * new Vector2(Input.GetAxis("Horizontal") * (jc.onGround ? 1 : airControl), 0));
		float tileNumber = Mathf.FloorToInt(transform.position.x);
		//Debug.Log(tileNumber);
    }
	
    void Death() {
        if (this.isAlive) {
            this.isAlive = false;
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
    }
	
}
