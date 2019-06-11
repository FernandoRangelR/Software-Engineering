using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentObject = null;
    public InteractableObject currentObjScript = null;
    public PlayerInventory playerInventory;



    //e is interact button
    private void Update()
    {
        if (currentObject)
        {
            //check if object can be picked up
            if (currentObjScript.inventoryAddable == true)
            {
                playerInventory.AddItem(currentObject);
            }
            //check if object can be opened
            if (currentObjScript.canBeOpened)
            {
                if (currentObjScript.locked)
                {
                    currentObjScript.Speak();
                }
                //if object is not locked
                else
                {
                    //have to add in animation to open the item
                    Debug.Log(currentObject.name + " is open.");
                    //triggers animation
                    currentObjScript.Open();
                }
            }
            //check if object has message
            if (currentObjScript.talks == true)
            {
                //tell wizard to give message
                currentObjScript.Speak();

            }
        }

    }


    //detects the object when the character comes close to it
    //all objects that are interactable have to be tagged as "interactableObj" in unity
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("interactableObj"))
        {
            currentObject = collision.gameObject;
            currentObjScript = currentObject.GetComponent<InteractableObject>(); //stores the current objects script
        }
    }


    //clears the object from the character view when he walks away from it
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("interactableObj"))
        {
            if (collision.gameObject == currentObject)
            {
                currentObject = null;
                currentObjScript.EndDialogue();
            }
        }
    }

}
