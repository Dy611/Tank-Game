using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Destructible")]
    public class DestructibleProfile : ScriptableObject
    {
        [Header("Destructible Stats")]
        [Tooltip("Amount Of Damage Destructible Can Take Before Death")]
        public int health;
        [Tooltip("Time Delay Before The Destructible Respawns")]
        public float respawnTime;

        [Header("Destructible Visuals")]
        [Tooltip("Visual Of The Destructible")]
        public Sprite visual;
    }
}