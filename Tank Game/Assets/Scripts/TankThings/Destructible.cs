using UnityEngine;
using TankGame.Profiles;

namespace TankGame
{
    //NOT RESPAWNING CORRECTLY
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Destructible : MonoBehaviour
    {
        public bool randomize;

        public DestructibleProfile dProfile;

        public bool respawn;
        [HideInInspector]
        public bool respawning;

        public float respawnTime { get; private set; }
        public Health health { get; private set; }

        private SpriteRenderer sRend;

        private void Awake()
        {
            health = GetComponent<Health>();
            sRend = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            respawning = false;
            if (randomize || dProfile == null)
            {
                dProfile = Randomizer.GetDestructibleProfile();
                if (dProfile == null)
                {
                    Randomizer.ThrowError(gameObject.name);
                    return;
                }
            }

            respawnTime = dProfile.respawnTime;
            sRend.sprite = dProfile.visual;
            health.maxHealth = dProfile.health;
        }
    }
}