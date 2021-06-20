using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Projectile")]
    public class ProjectileProfile : ScriptableObject
    {
        [Header("Projectile Stats")]
        [Tooltip("Amount Of Damage Projectile Deals On Impact")]
        public int damage;
        [Tooltip("The Speed Of The Projectile While Moving")]
        public float speed;

        [Header("Projectile Graphics")]
        [Tooltip("Visual Of The Projectile While Moving")]
        public Sprite projectileGraphic;
        [Tooltip("Visual Of The Projectile Hitting Something")]
        public Sprite hitGraphic;
    }
}