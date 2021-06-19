using System.Collections;
using UnityEngine;
using TankGame.Profiles;

namespace TankGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private bool randomize;

        [SerializeField]
        private WeaponProfile wProfile;
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

        protected virtual void InitializeWeapon()
        {
            if (randomize)
                wProfile = Randomizer.GetWeaponProfile();

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
                    proj.pProfile = Randomizer.GetProjectileProfile();
                else
                    proj.pProfile = wProfile.pProfile;

                proj.gameObject.SetActive(true);
                proj.transform.position = firePos.position;
                proj.transform.rotation = transform.rotation;
                canFire = false;
                shootVFX.gameObject.SetActive(true);
                StartCoroutine(FireDelay(wProfile.fireRate));
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