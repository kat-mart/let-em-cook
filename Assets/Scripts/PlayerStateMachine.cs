using System.Collections;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private enum PlayerState { Normal, Stunned, Invincible }

    private PlayerState currentState = PlayerState.Normal;

    private Rigidbody2D rigidBody;
    private PlayerAnimator playerAnimator;
    private PlayerMovement playerMovement;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    public void OnHitByEnemy(Vector2 enemyPosition)
    {
        if (!IsVulnerable()) return;

        ApplyKnockback(enemyPosition);
        TransitionToStunned();
    }
    
    public bool IsStunned()
    {
        return currentState == PlayerState.Stunned;
    }

    public bool IsInvincible()
    {
        return currentState == PlayerState.Invincible;
    }

    // The player can only be stunned when in the Normal state.
    private bool IsVulnerable()
    {
        return currentState == PlayerState.Normal;
    }
    
    private void ApplyKnockback(Vector2 enemyPosition)
    {
        Vector2 knockbackDirection = GetKnockbackDirection(enemyPosition);
        rigidBody.linearVelocity = new Vector2(knockbackDirection.x * GameParameters.PlayerKnockbackForce, rigidBody.linearVelocity.y);
        StartCoroutine(StopKnockbackAfterDelay());
    }
    
    private IEnumerator StopKnockbackAfterDelay()
    {
        yield return new WaitForSeconds(GameParameters.PlayerKnockbackDuration);
        rigidBody.linearVelocity = new Vector2(0f, rigidBody.linearVelocity.y);
    }
    
    private Vector2 GetKnockbackDirection(Vector2 enemyPosition)
    {
        float directionX = transform.position.x - enemyPosition.x;
        return new Vector2(Mathf.Sign(directionX), 0f);
    }

    private void TransitionToStunned()
    {
        currentState = PlayerState.Stunned;
        //playerAnimator.SetStunned(true);

        // Zero out horizontal input so the player doesn't start moving immediately
        // when the stun ends with a direction still held on the controller
        playerMovement.ResetHorizontalInput();

        StartCoroutine(StunSequence());
    }
    
    private IEnumerator StunSequence()
    {
        yield return new WaitForSeconds(GameParameters.PlayerStunDuration);

        currentState = PlayerState.Invincible;
        //playerAnimator.SetStunned(false);

        yield return new WaitForSeconds(GameParameters.PlayerInvincibilityDuration);

        currentState = PlayerState.Normal;
    }
}
