using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDetection : MonoBehaviour
{
    public Recipebook Recipebook;
    public Stove Stove;
    public CuttingBoard CuttingBoard;
    public Player Player;
    [SerializeField] private float interactionRange = 2f;

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
            ObjectClickedActions(hit);
        }
    }

    private void ObjectClickedActions(Collider2D hit)
    {
        Vector3 playerPos = Player.GetPlayerPosition();

        if (hit.gameObject == Recipebook.gameObject)
        {
            Recipebook.MouseClickDetected();
        }
        else
        {
            // Distance from player to clicked object
            float distance = Vector3.Distance(playerPos, hit.transform.position);

            // Only interact if close enough
            if (distance <= interactionRange)
            {
                if (hit.gameObject == Stove.gameObject)
                {
                    Stove.MouseClickDetected();
                }
                else if (hit.gameObject == CuttingBoard.gameObject)
                {
                    CuttingBoard.MouseClickDetected();
                }
            }
        }
    }
}