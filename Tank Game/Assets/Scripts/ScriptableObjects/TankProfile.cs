using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Tank")]
    public class TankProfile : ScriptableObject
    {
        [Header("Tank Stats")]
        [Range(0,50)]
        [Tooltip("Amount Of Damage Tank Can Take Before Death")]
        public int health;
        [Range(0, 50)]
        [Tooltip("Speed Of The Tank Movement")]
        public float speed;
        [Range(0,50)]
        [Tooltip("Speed The Tank Turns")]
        public float turnSpeed;
        [Range(0, 1)]
        [Tooltip("Time Delay Between Spawning Tracks")]
        public float trackDelay;

        [Header("Tank Graphics")]
        [Tooltip("Visual Of The Tank")]
        public Sprite tankGraphic;

        [Tooltip("Visual Of The Tracks The Tank Creates")]
        public Sprite trackGraphic;
    }
}