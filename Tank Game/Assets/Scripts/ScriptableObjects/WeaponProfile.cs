using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Weapon")]
    public class WeaponProfile : ScriptableObject
    {
        /// <summary>
        /// Time Delay Between Shots
        /// </summary>
        public float fireRate;

        /// <summary>
        /// Visual Of The Barrel
        /// </summary>
        public Sprite barrelGraphic;

        /// <summary>
        /// Visual of Shooting
        /// </summary>
        public Sprite shotGraphic;

        /// <summary>
        /// Should Weapon Shoot Random Projectiles
        /// </summary>
        public bool randomProjectile;

        /// <summary>
        /// Default Projectile To Shoot
        /// </summary>
        public ProjectileProfile pProfile;
    }
}