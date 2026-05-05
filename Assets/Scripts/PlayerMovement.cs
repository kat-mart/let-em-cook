using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    public Rigidbody2D playerBody;

    public void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    public void FixedUpdate()
    {
        
    }
}
