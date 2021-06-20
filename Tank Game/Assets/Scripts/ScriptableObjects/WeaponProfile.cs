using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Weapon")]
    public class WeaponProfile : ScriptableObject
    {
        [Header("Gun Stats")]
        [Tooltip("Have The Gun Fire A Random Projectile Every Time It Fires")]
        public bool randomProjectile;
        [Tooltip("Time Delay Between Shots")]
        public float fireDelay;

        [Header("Gun Graphics")]
        [Tooltip("Visual Of The Weapon Barrel Itself")]
        public Sprite barrelGraphic;
        [Tooltip("Visual Of The VFX When Firing")]
        public Sprite shotGraphic;

        [Header("Projectile To Shoot")]
        [Tooltip("The Projectile The Weapon Will Fire")]
        public ProjectileProfile pProfile;
    }
}