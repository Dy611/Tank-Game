using UnityEngine;
using TankGame.Profiles;

namespace TankGame
{
    //NOT RESPAWNING CORRECTLY
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Destructible : MonoBehaviour, IRandomizeAble
    {
        public bool randomized;

        public DestructibleProfile dProfile;

        public bool respawn;
        [HideInInspector]
        public bool respawning;

        public float respawnTime { get; private set; }
        public Health health { get; private set; }

        private SpriteRenderer sRend;

        public void randomize()
        {
            randomized = true;
        }

        private void Awake()
        {
            health = GetComponent<Health>();
            sRend = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            respawning = false;
            if (randomized || dProfile == null)
            {
                dProfile = ProfilesManager.GetProfile(ProfilesManager.destrucProfiles);
                if (dProfile == null)
                {
                    ProfilesManager.ThrowError(gameObject.name);
                    return;
                }
            }

            respawnTime = dProfile.respawnTime;
            sRend.sprite = dProfile.visual;
            health.maxHealth = dProfile.health;
        }
    }
}