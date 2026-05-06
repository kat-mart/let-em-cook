using UnityEngine;
using System.Collections;

public class TimedObject : MonoBehaviour
{
    public float secondsOnScreen = 1f;
    public void Start()
    {
        // start the timer to remove
        StartCoroutine(CoundownUntilDeath());
    }
    // create a timer that counts down and removes
    IEnumerator CoundownUntilDeath()
    {
        yield return new WaitForSeconds(secondsOnScreen);
        Destroy(gameObject);
    }
}