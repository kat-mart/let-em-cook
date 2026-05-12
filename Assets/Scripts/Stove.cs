using UnityEngine;

public class Stove : MonoBehaviour
{
    private bool isStoveClicked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseClickDetected()
    {
        isStoveClicked = true;
        print("Clicked Stove");
        isStoveClicked = false;
    }
}
