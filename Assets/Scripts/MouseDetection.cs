using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDetection : MonoBehaviour
{
    public Recipebook Recipebook;
    void Update()
    {
        if (Mouse.current == null)
            return;
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Recipebook.MouseClickDetected();
        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0f;
        return mouseWorld;
    }
}
