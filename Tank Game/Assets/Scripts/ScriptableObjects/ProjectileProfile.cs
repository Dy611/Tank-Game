using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Projectile")]
    public class ProjectileProfile : ScriptableObject
    {
        /// <summary>
        /// Damage Projectile Should Deal
        /// </summary>
        public int damage;

        /// <summary>
        /// Travel Speed Of Projectile
        /// </summary>
        public float speed;

        /// <summary>
        /// Visual Of Projectile
        /// </summary>
        public Sprite projectileGraphic;

        /// <summary>
        /// Visual Of Hitting Something
        /// </summary>
        public Sprite hitGraphic;
    }
}