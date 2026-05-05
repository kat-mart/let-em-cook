using UnityEngine;

public static class GameParameters
{
// --- Player Movement ---
    public static float PlayerSpeed = 8f;
    public static float PlayerJumpingPower = 16f;
    public static float PlayerDoubleJumpPower = 13f;

    // Multiplies gravity while falling so the jump arc feels snappy rather than floaty.
    // Higher values make the fall faster. 1.0 means normal gravity.
    public static float PlayerFallGravityMultiplier = 2.5f;
}
