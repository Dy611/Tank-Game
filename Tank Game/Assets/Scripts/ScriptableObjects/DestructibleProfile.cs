using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Destructible")]
    public class DestructibleProfile : ScriptableObject
    {
        public int health;

        public float respawnTime;

        public Sprite visual;
    }
}