using System.Collections;
using UnityEngine;
using TankGame.Profiles;

namespace TankGame
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        public ProjectileProfile pProfile;

        [HideInInspector]
        public bool canUse;

        private Rigidbody2D rb;
        private SpriteRenderer sRend;
        private CircleCollider2D col;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sRend = GetComponent<SpriteRenderer>();
            col = GetComponent<CircleCollider2D>();
        }

        protected virtual void OnEnable()
        {
            //Late OnEnable To Allow For Profiles To Be Set
            StartCoroutine(LateOnEnable());
        }

        private IEnumerator LateOnEnable()
        {
            yield return new WaitForEndOfFrame();
            InitializeProjectile();
        }

        protected virtual void InitializeProjectile()
        {
            canUse = false;
            sRend.sortingOrder = 2;
            col.radius = 0.25f;
            sRend.sprite = pProfile.projectileGraphic;
            col.isTrigger = true;
            rb.gravityScale = 0;
            rb.AddForce(transform.up * pProfile.speed);
            col.enabled = true;
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageAble iDamageAble))
                iDamageAble.TakeDamage(pProfile.damage);

            StartCoroutine(Deactivate());
        }

        protected virtual IEnumerator Deactivate()
        {
            col.enabled = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            sRend.sprite = pProfile.hitGraphic;
            yield return new WaitForSeconds(0.1f);
            gameObject.SetActive(false);
            canUse = true;
        }
    }
}