using System;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCollector : MonoBehaviour
{	
	
	// Create list for INVENTORY
	public List<GameObject> inventory = new List<GameObject>();
	
	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'.
	public void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Ingredient"))
		{
			Debug.Log("Ingredient detected");
			CollectItem(other.gameObject);
			other.gameObject.SetActive(false);
		}
	}
	
	private void InventoryStatusUpdate()
	{
		foreach (GameObject item in inventory)
		{
			print(item.GetComponent<Item>().itemName);
		}
	}
	
	private void CollectItem(GameObject item)
	{
		inventory.Add(item);
		InventoryStatusUpdate();
		
	}
}