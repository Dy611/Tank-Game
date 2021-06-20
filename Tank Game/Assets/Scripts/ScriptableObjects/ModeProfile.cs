using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Game Mode")]
    public class ModeProfile : ScriptableObject
    {
        [Header("Main Rules")]
        [Range(0, 20)]
        [Tooltip("The Amount Of Points Needed To Win The Match")]
        public int winningScore;
        [Range(0, 10)]
        [Tooltip("The Time Delay Before A Player Respawns")]
        public float respawnDelay;

        [Header("Randomization")]
        [Tooltip("Tanks Are Random Every Respawn")]
        public bool randomTanks;
        [Tooltip("Weapons Are Random Every Respawn")]
        public bool randomWeapons;
        [Tooltip("Projectiles Are Random Every Respawn")]
        public bool randomProjectiles;
        [Tooltip("Destructibles Are Random Every Time They Respawn")]
        public bool randomDestructibles;

        [Header("Player 1")]
        [Tooltip("The Tank Index Player 1 Will Use")]
        public int player1Tank;
        [Tooltip("The Weapon Index Player 1 Will Use")]
        public int player1Weapon;
        [Tooltip("The Projectile Index Player 1 Will Use")]
        public int player1Projectile;

        [Header("Player 2")]
        [Tooltip("The Tank Index Player 2 Will Use")]
        public int player2Tank;
        [Tooltip("The Weapon Index Player 2 Will Use")]
        public int player2Weapon;
        [Tooltip("The Projectile Index Player 2 Will Use")]
        public int player2Projectile;
    }
}