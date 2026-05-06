using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;
    
    public float miniSecondsToWait;
    public float maxSecondsToWait;
    private bool isOkToCreate = true;
    private bool isActive = false;
    private Coroutine coundownCoroutine;
    
    void Update()
    {
        if (!isActive)
            return;
        
        if (isOkToCreate)
        {
            coundownCoroutine = StartCoroutine(CountdownUntilCreation());
        }
    }

    public void StartPlacing()
    {
        isActive = true;
        isOkToCreate = true;
    }
    public void StopPlacing()
    {
        isActive = false;
        isOkToCreate = false;
        if (coundownCoroutine != null)
        {
            StopCoroutine(coundownCoroutine);
        }

        CleanupPlacedObjects();
    }

    private void CleanupPlacedObjects()
    {
        // find all objects placed that are still on the board
        List<GameObject> placedObjects = GameObject.FindGameObjectsWithTag(Prefab.tag).ToList();
        // destroy them
        for (int i = 0; i < placedObjects.Count; i++)
        {
            Destroy(placedObjects[i]);
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
        
        float secondsToWait = Random.Range(miniSecondsToWait, maxSecondsToWait);
        
        yield return new WaitForSeconds(secondsToWait);
        Place();
        isOkToCreate = true;    
    }

    public virtual void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}