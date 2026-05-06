using UnityEngine;

public class Food : TimedObject
{
    public void Start()
    {
        //secondsOnScreen = GameParameters.MoonshineSecondsOnScreen;
        secondsOnScreen = 10f;
        base.Start();
    }
}