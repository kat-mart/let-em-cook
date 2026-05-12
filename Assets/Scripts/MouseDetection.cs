using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDetection : MonoBehaviour
{
    public Recipebook Recipebook;
    public Stove Stove;

    void Update()
    {
        if (Mouse.current == null)
            return;
        
        CheckIfObjectClicked();
        
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);

        mouseWorld.z = 0f;

        return mouseWorld;
    }
    
    private Collider2D CheckIfMouseTouchedCollider()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePos = GetMouseWorldPosition();
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            return hit;
        }
        return null;
    }

    private void CheckIfObjectClicked()
    {
        Collider2D hit = CheckIfMouseTouchedCollider();
        if (hit != null)
        { 
            if (hit.gameObject == Recipebook.gameObject)
            {
                Recipebook.MouseClickDetected();
            }
            else if (hit.gameObject == Stove.gameObject)
            {
                Stove.MouseClickDetected();
            }
        }
    }
    
}