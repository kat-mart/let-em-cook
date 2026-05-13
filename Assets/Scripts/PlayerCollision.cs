using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public BoxCollider2D GroundCollider;
    public LayerMask GroundLayer;
    public LayerMask OneWayPlatformLayer;
    
    private Rigidbody2D rigidBody;
    private PlayerStateMachine playerStateMachine;
    
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
    }
    
    public bool IsGrounded()
    {
        LayerMask landableLayers = GroundLayer | OneWayPlatformLayer;

        return Physics2D.OverlapBox(
            GroundCollider.bounds.center,   // centre of the box in world space
            GroundCollider.bounds.size,     // width and height of the box
            0f,                             // rotation of the box (0 = no rotation)
            landableLayers                  // only detect these layers
        );
    }
    
    public bool IsRising()
    {
        return rigidBody.linearVelocity.y > 0f;
    }
    
    public bool IsFalling()
    {
        return rigidBody.linearVelocity.y < 0f;
    }
    
    public void UpdateOneWayPlatformCollision()
    {
        int playerLayerIndex = gameObject.layer;
        int oneWayPlatformLayerIndex = GetLayerIndex(OneWayPlatformLayer);

        Physics2D.IgnoreLayerCollision(playerLayerIndex, oneWayPlatformLayerIndex, IsRising());
    }
    
    private int GetLayerIndex(LayerMask mask)
    {
        return Mathf.RoundToInt(Mathf.Log(mask.value, 2));
    }
}
