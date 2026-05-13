using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Inventory : MonoBehaviour
{
    public Tilemap InventoryOverlay;
    public List<InventorySlot> InventorySlots;
    private TileBase[] inventory = new TileBase[10];

    public TileBase[] getInventory()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            Debug.Log(inventory[i]);
        }
        return inventory;
    }
    
    public void AddItemToEmptyInventorySlot(TileBase add)
    {
        int emptySlot = -1; // assume no empty slots in inventory
        Debug.Log("Adding item to empty slot");
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                emptySlot = i; // an empty slot in inventory found
                inventory[i] = add;
                Debug.Log("Adding item to empty slot: " + i);
                break;
            }
        }
        // add TileBase in correct inventory slot in game...
        if (emptySlot == -1)
        {
            return;
        }
        Vector3Int cellPosition = InventorySlots[emptySlot].GetInventorySlotPosition();
        InventoryOverlay.SetTile(cellPosition, add);
    }
    
    public TileBase RemoveItemFromInventorySlot(int i)
    {
        Debug.Log("Removing item from inventory slot");
        // need to use mouse detection to check which slot player is selecting
        // find index of corresponding box
        TileBase tileToPlace = inventory[i];
        inventory[i] = null;
        // empty slot at index
        return tileToPlace; // for PlayerInteractions to know which tile to place
    }
    
    
}
