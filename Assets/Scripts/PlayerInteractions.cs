using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInteractions : MonoBehaviour
{
    public Tilemap InteractTilemap;
    public TileBase TileToPlace; // will change based on player inventory 
    
    public void OnPickup()
    {
        Debug.Log("Picked up");
        PickupTile();
    }

    private void PickupTile()
    {
        if (InteractTilemap == null )
        {
            return;
        }
        Vector3Int cellPosition = InteractTilemap.WorldToCell(transform.position);
        InteractTilemap.SetTile(cellPosition, null);
    }

    public void OnDrop()
    {
        Debug.Log("Dropped");
        DropTile();
    }

    private void DropTile()
    {
        if (InteractTilemap == null || TileToPlace == null)
        {
            return;
        }
        Vector3Int  cellPosition = InteractTilemap.WorldToCell(transform.position);
        if (CellEmpty(cellPosition))
        {
            InteractTilemap.SetTile(cellPosition, TileToPlace);
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
