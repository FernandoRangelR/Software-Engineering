using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InteractableObject : MonoBehaviour
{
    public bool inventoryAddable;  //can be stored in inventory
    public bool canBeOpened; //an object can be opened
    public bool locked; //object can be opened, but is locked
    public bool talks; //the object can talk to character
    public bool activeDialogue; //used for interacting with wizard in room 10

    public GameObject wizardBox;
    public TextMeshProUGUI wizardText;

    public GameObject neededItem; //item that is needed to unlock a locked object
    public Animator anim; //can be used with animated objects (e.g. chests/doors)


    public void InteractWithChar()
    {
        //pick up and put inventory
        gameObject.SetActive(false);
    }

    //controls animation for opening objects
    public void Open()
    {
        anim.SetBool("open", true);
    }


    //object has a message
    public void Speak()
    { 
        activeDialogue = true;
        wizardBox.SetActive(true);
    
    }

    //close message box from wizard
    public void EndDialogue()
    {
        activeDialogue = false;
        wizardBox.SetActive(false);
    }
}
