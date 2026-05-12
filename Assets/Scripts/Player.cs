using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Food Food;
    public float respawnTimeInSeconds = 3f;

    public void CollectItem(Collider other)
    {
        if (other.CompareTag("Bubble"))
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            Food.RespawnObject(other.gameObject);
        }
    }
    
}