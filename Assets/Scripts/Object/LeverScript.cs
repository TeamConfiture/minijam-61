using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeverScript : Interactable
{
    [Header("Attributes")]
    public bool isActive;

    [Header("Related Content")]
    public TorchScript[] myGameObjects;

    private bool prevState;

    private SpriteRenderer sRenderer;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro tmp = GetComponentInChildren<TextMeshPro>();
        sRenderer = GetComponent<SpriteRenderer>();
        //theAnim.SetBool("active", isActive); // This means for each primitve data type there's a setter.
        if(tmp != null)
        {
            tmp.text = string.Format(InteractionText, InteractionCommand);
        }

        MakeInteractable(false);
        prevState = isActive;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevState != isActive) {
            prevState = isActive;
            sRenderer.flipX = isActive;
            // Debug.Log("State switched !");
            //theAnim.SetBool("active", isActive); // This means for each primitve data type there's a setter.
            this.ChangeStateObjects();
        }
    }

    public void ChangeStateObjects() {
        foreach (TorchScript elem in myGameObjects) {
            elem.SwitchState();
        }
    }

    public override void Interact() {
        // Debug.Log("Hep !");
        isActive = !isActive;
    }

    /*void OnTriggerStay(Collider other){
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F)){
            Debug.Log("Hep !");
        }
    }*/
}
