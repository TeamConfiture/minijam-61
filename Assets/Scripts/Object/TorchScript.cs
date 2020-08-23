using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    [Header("Attributes")]
    public bool isActive = true;

    private bool prevState = false;

    private Animator theAnim;

    // Start is called before the first frame update
    void Start()
    {
        theAnim = GetComponent<Animator>();
        theAnim.SetBool("active", isActive); // This means for each primitve data type there's a setter.
    }

    // Update is called once per frame
    void Update()
    {
        if (prevState != isActive) {
            prevState = isActive;
            // Debug.Log("State switched !");
            theAnim.SetBool("active", isActive); // This means for each primitve data type there's a setter.
        }
    }

    // Switch State
    public void SwitchState(bool newState) {
        if (newState != isActive) {
            isActive = newState;
            // Debug.Log("State changed !");
        }
    }
}
