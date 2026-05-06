using UnityEngine;

// Central location for all tunable game design values.
// Designers can adjust these values here without digging through individual scripts.
// In a larger project these might live in a JSON or ScriptableObject,
// but a static class keeps things simple and easy to find.
public static class GameParameters
{
    // --- Player Movement ---
    public static float PlayerSpeed = 8f;
    public static float PlayerJumpingPower = 8f;
    public static float PlayerDoubleJumpPower = 10f;

    // Multiplies gravity while falling so the jump arc feels snappy rather than floaty.
    // Higher values make the fall faster. 1.0 means normal gravity.
    public static float PlayerFallGravityMultiplier = 5f;

    // --- Player Stun ---
    public static float PlayerStunDuration = 2f;
    public static float PlayerInvincibilityDuration = 5f;
    public static float PlayerKnockbackForce = 8f;

    // How long the knockback impulse lasts before the player stops sliding.
    public static float PlayerKnockbackDuration = 0.15f;

    // --- Player FX ---

    // Minimum downward speed required to trigger the landing poof and screen shake.
    public static float PlayerMinFallSpeedToTrigger = 2f;

    // Strength of the screen shake on landing. Higher values shake more.
    public static float PlayerLandingShakeForce = 1f;

    // --- Enemy ---
    public static float EnemySpeed = 2f;
    public static float EnemyDamage = 10f;

    // How far ahead of the enemy's feet to check for a platform edge.
    // Increase this if enemies walk off edges before turning.
    public static float EnemyEdgeRaycastDistance = 0.5f;

    // How far ahead to check for a level boundary wall.
    public static float EnemyWallRaycastDistance = 0.5f;

    // How long to wait after turning before checking for edges or walls again.
    // Without this, the enemy would flip back and forth every frame at an edge.
    public static float EnemyFlipCooldownDuration = 0.3f;

    // --- Enemy Spawner ---
    public static int MaxEnemies = 5;
}