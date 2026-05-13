using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevelPhysics2D;
using UnityEngine.Tilemaps;

public class InventorySlot : MonoBehaviour
{
    public Tilemap InventoryOverlay;
    private Vector3Int inventorySlotPosition;

    public void Awake()
    {
        inventorySlotPosition = InventoryOverlay.WorldToCell(transform.position);
    }

    public Vector3Int GetInventorySlotPosition()
    {
        return inventorySlotPosition;
    }
}
