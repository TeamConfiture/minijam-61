using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string InteractionCommand = "Fire1";
    public string InteractionText = "{0} to talk";
    public GameObject InteractionPopup;

    public bool Interacting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MakeInteractable(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            MakeInteractable(false);
        }
    }

    public void MakeInteractable(bool interactable)
    {
        GameManager.Instance.Interacting = interactable;
        Interacting = interactable;

        if (InteractionPopup != null)
            InteractionPopup.SetActive(interactable);

    }

    private void Update()
    {
        if(Interacting && Input.GetButtonDown(InteractionCommand))
        {
            MakeInteractable(false);
            Interact();
        }
    }

    public virtual void Interact()
    {

    }
}
