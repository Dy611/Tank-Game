using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Game Mode")]
    public class ModeProfile : ScriptableObject
    {
        [Range(0, 20)]
        public int winningScore;
        [Range(0, 10)]
        public float respawnDelay;

        public bool randomTanks;
        public bool randomWeapons;
        public bool randomProjectiles;
        public bool randomDestructibles;

        public int player1Tank;
        public int player1Weapon;
        public int player1Projectile;

        public int player2Tank;
        public int player2Weapon;
        public int player2Projectile;
    }
}