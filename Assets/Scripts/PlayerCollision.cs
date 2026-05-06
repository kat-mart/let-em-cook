using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public BoxCollider2D GroundCollider;
    public LayerMask GroundLayer;
    public LayerMask OneWayPlatformLayer;
    public LayerMask EnemyLayer;
    
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore the collision if it wasn't with an enemy
        if (!IsEnemyContact(collision))
            return;

        // Pass the enemy's position to the state machine so it can calculate
        // the knockback direction (away from wherever the enemy was)
        Vector2 enemyPosition = collision.transform.position;
        playerStateMachine.OnHitByEnemy(enemyPosition);
    }

    private bool IsEnemyContact(Collision2D collision)
    {
        int layer = 1 << collision.gameObject.layer;
        return (layer & EnemyLayer) != 0;
    }
    
    private int GetLayerIndex(LayerMask mask)
    {
        return Mathf.RoundToInt(Mathf.Log(mask.value, 2));
    }
}
