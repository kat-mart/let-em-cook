using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public IngredientCollector IngredientCollector;
    public PlayerInteractions PlayerInteractions;
    public MouseDetection MouseDetection;
    public Food Food;
    public float respawnTimeInSeconds = 3f;

    public void CollectItem(Collider2D other)
    {
        if (other.CompareTag("Ingredient"))
        {
            Debug.Log("Collected Ingredient");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            Food.RespawnObject(other.gameObject);
        }

        if (other.CompareTag("Ingredient"))
        {
            Debug.Log("Ingredient detected");
            IngredientCollector.CollectItem(PlayerInteractions.OnPickup());
            other.gameObject.SetActive(false);
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return  transform.position;
    }
}