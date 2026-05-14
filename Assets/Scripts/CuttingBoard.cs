using UnityEngine;
using System.Collections;

public class CuttingBoard : MonoBehaviour
{
    private bool isBoardClicked = false;

    private float timeToChop = 2f;
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
        isBoardClicked = true;
        ChopFood();
    }

    private void ChopFood()
    {
        print("Chopping Food");
        StartCoroutine(StartChopping());
    }

    private IEnumerator StartChopping()
    {
        yield return new WaitForSeconds(timeToChop);
        DoneChoppingFood();
    }

    private void DoneChoppingFood()
    {
        isBoardClicked = false;
        print("Food CHOPPED");
    }
}
