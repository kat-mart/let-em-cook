using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{
    public float respawnTimeInSeconds = 3f;

    public void RespawnObject(GameObject bubble)
    {
        StartCoroutine(Respawn(bubble));
    }

    private IEnumerator Respawn(GameObject bubble)
    {
        bubble.SetActive(false);

        yield return new WaitForSeconds(respawnTimeInSeconds);

        bubble.SetActive(true);
    }
}