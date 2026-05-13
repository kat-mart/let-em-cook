using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Food Ingredient;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void CollectItem(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    { // Collide with ingredient or kitchen utility
        if (other.CompareTag("Ingredient"))
        {
            Ingredient.RespawnObject(other.gameObject);
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return spriteRenderer.transform.position;
    }
    
}