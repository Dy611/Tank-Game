using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Tank")]
    public class TankProfile : ScriptableObject
    {
        /// <summary>
        /// Health Of Tank
        /// </summary>
        public int health;

        /// <summary>
        /// Speed Of Tank
        /// </summary>
        public float speed;

        /// <summary>
        /// Speed Of Tank's Rotation
        /// </summary>
        public float turnSpeed;

        /// <summary>
        /// Time Between Track Spawns
        /// </summary>
        [Range(0, 1)]
        public float trackDelay;

        /// <summary>
        /// Visual Of Tank
        /// </summary>
        public Sprite tankGraphic;

        /// <summary>
        /// Visual Of Tire Tracks
        /// </summary>
        public Sprite trackGraphic;
    }
}