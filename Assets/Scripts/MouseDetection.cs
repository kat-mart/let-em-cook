using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDetection : MonoBehaviour
{
    public Recipebook recipebook;

    void Update()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePos = GetMouseWorldPosition();

            // Check if mouse is touching the sprite collider
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject == recipebook.gameObject)
            {
                recipebook.MouseClickDetected();
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();

        Vector3 mouseWorld =
            Camera.main.ScreenToWorldPoint(mouseScreen);

        mouseWorld.z = 0f;

        return mouseWorld;
    }
}