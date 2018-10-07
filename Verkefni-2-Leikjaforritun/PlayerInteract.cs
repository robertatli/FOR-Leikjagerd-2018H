using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {// player interact script

    public GameObject currentInterObj = null; // núverandi selected gameObject

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)// ef currentInterObject er true og ýtt er á interact takkann
        {
            currentInterObj.SendMessage("DoInteraction");//sendir á InteractionObject.cs að það eigi að gera interactionið
            Debug.Log(Input.GetButtonDown("Interact")); // skrifar í console að interactað var við object
        }
    }

    void OnTriggerEnter2D(Collider2D other)// ef player fer inn í colliderinn
    {
        if (other.CompareTag("InterObject"))// ef objectið er með tagið InterObject
        {
            Debug.Log(other.name);// consolear nafn á objectinu
            currentInterObj = other.gameObject; // setur objectið sem currentInterObj
        }
    }
    private void OnTriggerExit2D(Collider2D other)// ef player fer úr colliderinum
    {
        if (other.CompareTag("InterObject"))// og colliderinn var með taggið interObject
        {
            if (other.gameObject == currentInterObj)// og currentInterObj er sama og var í geameObjectinu
            {
                currentInterObj = null;// setur currentInterObj sem null
            }
        }
    }
}
