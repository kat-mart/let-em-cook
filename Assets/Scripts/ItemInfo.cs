using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    // This class stores information
    // about each item in the game.
    
    public string itemName;
    public int itemCount;
    public bool isCollectable = false;
    
    // ITEMS for our Inventory list - this is purely information for your list
    public Item(string name, int quantity, GameObject other)
    {
        name = itemName;
        quantity = itemCount;
        
        if (other.gameObject.CompareTag("Player"))
        {
            isCollectable = true;
        }
        else
        {
            isCollectable = false;
        }
        
    }
    
}
