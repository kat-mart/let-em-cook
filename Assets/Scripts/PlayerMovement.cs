using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    public Rigidbody2D Rigidbody;
    private float horizontal;
    private bool canDoubleJump;
    private bool isJumping;
    private float defaultGravityScale;
    private bool isFacingRight;
    
    private PlayerCollision playerCollision;
    private PlayerStateMachine playerStateMachine;
    private PlayerAnimator playerAnimator;
    private PlayerFX playerFX;
    private JumpSquashStretch jumpSquashStretch;

    private void Start()
    {
        defaultGravityScale = Rigidbody.gravityScale;

        playerCollision = GetComponent<PlayerCollision>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerFX = GetComponent<PlayerFX>();
        jumpSquashStretch = GetComponentInChildren<JumpSquashStretch>();
    }

    private void Update()
    {
        bool grounded = playerCollision.IsGrounded();
        
        playerCollision.UpdateOneWayPlatformCollision();
        
        ApplyFallGravity(grounded);
        
        if (!playerStateMachine.IsStunned())
        {
            Flip();
        }
        
        //playerAnimator.SetMovementState(IsRunning(grounded), isJumping, grounded);
        //playerFX.UpdateRunParticles(IsRunning(grounded));
    }

    private void FixedUpdate()
    {
        if (playerStateMachine.IsStunned()) return;
        
        Rigidbody.linearVelocity = new Vector2(horizontal * GameParameters.PlayerSpeed, Rigidbody.linearVelocity.y);
    }

    private void OnMove(InputValue value)
    {
        if (playerStateMachine.IsStunned()) return;

        horizontal = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;
        
        if (playerStateMachine.IsStunned()) return;

        if (playerCollision.IsGrounded())
        {
            Rigidbody.linearVelocity = new Vector2(Rigidbody.linearVelocity.x, GameParameters.PlayerJumpingPower);
            //jumpSquashStretch.OnJumped();
            StartJumpAnimation();
        }
        else if (canDoubleJump)
        {
            // Double jump: same idea but with a separate (usually lower) power value.
            // We immediately consume the double jump so it can only be used once.
            Rigidbody.linearVelocity = new Vector2(Rigidbody.linearVelocity.x, GameParameters.PlayerDoubleJumpPower);
            canDoubleJump = false;
            //jumpSquashStretch.OnJumped();
            StartJumpAnimation();
        }
    }
    
    public void ResetHorizontalInput()
    {
        horizontal = 0f;
    }

    private void Flip()
    {
        if (IsFacingWrongDirection())
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = localScale.x * -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsFacingWrongDirection()
    {
        return isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f;
    }

    private void StartJumpAnimation()
    {
        StopAllCoroutines();
        isJumping = true;
        StartCoroutine(ClearJumpOnLanding());
    }
    
    private void ApplyFallGravity(bool grounded)
    {
        if (playerCollision.IsFalling() && !grounded)
        {
            Rigidbody.gravityScale = defaultGravityScale * GameParameters.PlayerFallGravityMultiplier;
        }
        else
        {
            Rigidbody.gravityScale = defaultGravityScale;
        }
    }
    
    private bool IsRunning(bool grounded)
    {
        return horizontal != 0f && grounded;
    }
    
    private IEnumerator ClearJumpOnLanding()
    {
        // Wait until the player has actually left the ground
        while (playerCollision.IsGrounded())
        {
            yield return null;
        }

        // Now wait until the player lands again
        while (!playerCollision.IsGrounded())
        {
            yield return null;
        }

        // Player has landed — reset jump state and restore double jump
        isJumping = false;
        canDoubleJump = true;
    }
}
