using UnityEngine;

// Central location for all tunable game design values.
// Designers can adjust these values here without digging through individual scripts.
// In a larger project these might live in a JSON or ScriptableObject,
// but a static class keeps things simple and easy to find.
public static class GameParameters
{
    // --- Player Movement ---
    public static float PlayerSpeed = 6f;
    public static float PlayerJumpingPower = 6f;
    public static float PlayerDoubleJumpPower = 8f;

    // Multiplies gravity while falling so the jump arc feels snappy rather than floaty.
    // Higher values make the fall faster. 1.0 means normal gravity.
    public static float PlayerFallGravityMultiplier = 5f;

    // --- Player Stun ---
    public static float PlayerStunDuration = 2f;
    public static float PlayerInvincibilityDuration = 5f;
    public static float PlayerKnockbackForce = 8f;

    // How long the knockback impulse lasts before the player stops sliding.
    public static float PlayerKnockbackDuration = 0.15f;
}