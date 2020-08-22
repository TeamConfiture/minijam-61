using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string StartInteraction = "Fire1";
    public bool Interacting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter " + collision.tag);
        if (collision.tag == "Player")
        {
            GameManager.Instance.Interacting = true;
            Interacting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit " + collision.tag);
        if(collision.tag == "Player")
        {
            GameManager.Instance.Interacting = false;
            Interacting = false;
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown(StartInteraction))
        {
            Interact();
            Interacting = false;
        }
    }

    public virtual void Interact()
    {

    }
}
