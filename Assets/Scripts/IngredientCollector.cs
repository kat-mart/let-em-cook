using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IngredientCollector : MonoBehaviour
{
	public Inventory Inventory;
	
	public void CollectItem(TileBase item)
	{
		Debug.Log("Collecting item");
		Inventory.AddItemToEmptyInventorySlot(item);
	}
}