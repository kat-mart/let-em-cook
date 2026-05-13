using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IngredientCollector : MonoBehaviour
{
	public Inventory Inventory;
	
	// Create list for INVENTORY
	//public List<GameObject> inventory = new List<GameObject>();
	
	// maybe use an array to store the items because then it can only have X number of
	//public TileBase[] inventory = new TileBase[10];
	// slots and also some slots can be empty
	
	public void CollectItem(TileBase item)
	{
		Debug.Log("Collecting item");
		Inventory.AddItemToEmptyInventorySlot(item);
	}
}