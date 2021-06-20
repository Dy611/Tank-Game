using System.Collections;
using UnityEngine;
using TankGame.Profiles;
using TankGame.Managers;

namespace TankGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Weapon : MonoBehaviour, IRandomizeAble
    {
        public bool randomized;
        public bool randomizeProj { private get; set; }

        public WeaponProfile wProfile;
        public ProjectileProfile pProfile;

        [SerializeField]
        private Transform firePos;
        [SerializeField]
        private SpriteRenderer shootVFX, barrel;

        private bool canFire;
        private Projectile proj;

        protected virtual void OnEnable()
        {
            InitializeWeapon();
        }

        public void randomize()
        {
            randomized = true;
        }

        protected virtual void InitializeWeapon()
        {
            if (randomized)
                wProfile = ProfilesManager.GetProfile(ProfilesManager.weaponProfiles);

            if (randomizeProj)
                pProfile = ProfilesManager.GetProfile(ProfilesManager.projectileProfiles);
            else
                pProfile = wProfile.pProfile;

            barrel.sprite = wProfile.barrelGraphic;
            shootVFX.sprite = wProfile.shotGraphic;
            canFire = true;
        }

        public virtual void Shoot()
        {
            if (canFire)
            {
                proj = ProjectilePool.GetProjectile();

                if (wProfile.randomProjectile)
                    proj.pProfile = ProfilesManager.GetProfile(ProfilesManager.projectileProfiles);
                else
                    proj.pProfile = pProfile;

                proj.gameObject.SetActive(true);
                proj.transform.position = firePos.position;
                proj.transform.rotation = transform.rotation;
                canFire = false;
                shootVFX.gameObject.SetActive(true);
                StartCoroutine(FireDelay(wProfile.fireDelay));
            }
        }

        IEnumerator FireDelay(float delay)
        {
            yield return new WaitForSeconds(0.1f);
            shootVFX.gameObject.SetActive(false);
            yield return new WaitForSeconds(delay - 0.1f);
            canFire = true;
        }
    }
}