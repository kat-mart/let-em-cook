using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{
    public float respawnTimeInSeconds = 3f;

    public void RespawnObject(GameObject Ingredient)
    {
        StartCoroutine(Respawn(Ingredient));
    }

    private IEnumerator Respawn(GameObject Ingredient)
    {
        Ingredient.SetActive(false);

        yield return new WaitForSeconds(respawnTimeInSeconds);

        Ingredient.SetActive(true);
    }
}