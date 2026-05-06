using UnityEngine;

public class FoodPlacer : TimedObjectPlacer
{
    public void Start()
    {
        // miniSecondsToWait = GameParameters.FoodMinimumSecondsToWait;
        // maxSecondsToWait = GameParameters.FoodMaximumSecondsToWait;
        miniSecondsToWait = 3f;
        maxSecondsToWait = 7f;
    }

    public override void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
    }
}