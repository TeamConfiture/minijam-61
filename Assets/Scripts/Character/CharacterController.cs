using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Game Objects")]
    public Rigidbody2D rb;

    [Header("Multipliers")]
    public Vector2 movesMultiplier;
    public float airControl = 0.5f;

    JumpController jc;

    // Start is called before the first frame update
    void Start()
    {
        if(rb==null)
            rb = GetComponent<Rigidbody2D>();
        jc = GetComponentInChildren<JumpController>();
    }

    // Called every physics frame
    private void FixedUpdate()
    {
        rb.AddForce(movesMultiplier * new Vector2(Input.GetAxis("Horizontal") * (jc.onGround ? 1 : airControl), 0));
    }
}
