using UnityEngine;
using System.Collections;

namespace TankGame
{
    [RequireComponent(typeof(Collider2D))]
    public class Health : MonoBehaviour, IDamageAble
    {
        [HideInInspector]
        public float currHealth;

        [HideInInspector]
        public float maxHealth;

        public delegate void Damaged();
        public event Damaged OnDamaged;

        public delegate void Died();
        public event Died OnDeath;

        private void OnEnable()
        {
            //Late OnEnable To Allow For Profiles To Be Set
            StartCoroutine(LateOnEnable());
        }

        private IEnumerator LateOnEnable()
        {
            yield return new WaitForEndOfFrame();
            currHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            Mathf.Clamp(currHealth -= damage, 0, maxHealth);

            if(currHealth <= 0)
            {
                gameObject.SetActive(false);
                OnDeath?.Invoke();
                return;
            }

            if(GetComponent<SpriteRenderer>())
                StartCoroutine(HitFlash());

            OnDamaged?.Invoke();
        }

        IEnumerator HitFlash()
        {
            SpriteRenderer sRend = GetComponent<SpriteRenderer>();
            sRend.material.color = Color.white;
            float length = 0;

            while(length < 0.1f)
            {
                length += Time.deltaTime;
                sRend.material.color = Color.Lerp(Color.white, Color.red, length * 10);
                yield return null;
            }

            sRend.material.color = Color.white;
        }
    }
}