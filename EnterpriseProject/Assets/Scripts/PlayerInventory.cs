using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    //specifies how many objects the inventory can hold and sets it to a max of 20
    public GameObject[] inventory = new GameObject[2];

    //adds the object to the inventory
    public void AddItem(GameObject item)
    {
        bool addedItem = false;
        //find 1st empty slot in array
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + "has been added to the inventory");
                addedItem = true;
                item.SendMessage("InteractWithChar"); //tells object to interact with character
                break; //prevents the item from being added multiple times to the array
            }
        }

        //if the inventory is full
        if (addedItem == false)
        {
            Debug.Log("The inventory is full. " + item.name + " was not added");
        }
    }

    public bool SearchInventory(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //item found in inventory
                return true;
            }
        }
        //item not found in inventory
        return false;
    }
}
