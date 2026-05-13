using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInteractions : MonoBehaviour
{
    public Tilemap InteractTilemap;
    public Inventory Inventory;
    
    private TileBase TileToPlace; // will change based on player inventory 
    
    public TileBase OnPickup()
    {
        Debug.Log("Picked up");
        return PickupTile();
    }

    private TileBase PickupTile()
    {
        if (InteractTilemap == null )
        {
            return null;
        }
        Vector3Int cellPosition = InteractTilemap.WorldToCell(transform.position);
        if (InteractTilemap.GetTile(cellPosition) != null)
        {
            Inventory.AddItemToEmptyInventorySlot(InteractTilemap.GetTile(cellPosition));
            InteractTilemap.SetTile(cellPosition, null);
        }
        return InteractTilemap.GetTile(cellPosition);
    }

    public void OnDrop()
    {
        Debug.Log("Dropped");
        DropTile();
    }

    private void DropTile()
    {
        // figure out tile to place w/ mouse detection
        if (InteractTilemap == null || TileToPlace == null)
        {
            return;
        }
        Vector3Int  cellPosition = InteractTilemap.WorldToCell(transform.position);
        for (int i = Inventory.getInventory().Length - 1; i >= 0; i--)
        {
            if (Inventory.getInventory()[i] != null)
            {
                if (CellEmpty(cellPosition))
                {
                    InteractTilemap.SetTile(cellPosition, Inventory.getInventory()[i]);
                }
                break;
            }
        }
    }

    private bool CellEmpty(Vector3Int cellPosition)
    {
        if (InteractTilemap.GetTile(cellPosition) == null)
        {
            return true;
        }
        return false;
    }
}
