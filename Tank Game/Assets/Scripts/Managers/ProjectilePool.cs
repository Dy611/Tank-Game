using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Managers
{
    public class ProjectilePool : MonoBehaviour
    {
        /// <summary>
        /// Pooled List Of All Projectiles In The Scene
        /// </summary>
        private static readonly List<Projectile> projs = new List<Projectile>();

        /// <summary>
        /// The GameObject This Is Attached To
        /// </summary>
        private static GameObject projPooler;

        private void Awake()
        {
            //Assign Object Instance
            projPooler = gameObject;

            //Finds Any Precreated Tracks And Adds Them Into The List
            foreach (Projectile proj in Resources.FindObjectsOfTypeAll<Projectile>())
            {
                projs.Add(proj);
                //Enables These Projectiles To Be Usable
                proj.canUse = true;
            }
        }

        //Clears Old References On Scene Change
        private void OnDisable()
        {
            projs.Clear();
        }

        /// <summary>
        /// Looks For A Usable Projectile Inside List, Creates A New One If None Are Available
        /// </summary>
        /// <returns> Returns A Projectile </returns>
        public static Projectile GetProjectile()
        {
            //Looks Through Available Tracks
            for (int i = 0; i < projs.Count; i++)
                if (projs[i].canUse)
                    return projs[i];

            //Creates A New Projectile Since None Currently Are Available
            return CreateAnotherProjectile();
        }

        /// <summary>
        /// Creates A New GameObject And Makes It A Usable Projectile
        /// </summary>
        /// <returns> A Freshly Created GameObject And Projectile </returns>
        private static Projectile CreateAnotherProjectile()
        {
            //Creates A New GameObject And Increments The Name
            GameObject newProjObj = new GameObject("Projectile" + (projs.Count + 1));
            newProjObj.transform.parent = projPooler.transform;
            newProjObj.AddComponent<SpriteRenderer>();
            newProjObj.AddComponent<CircleCollider2D>();
            newProjObj.AddComponent<Rigidbody2D>();
            //Adds The Projectile Component And Adds This New Component To The Pool List
            Projectile newProj = newProjObj.AddComponent<Projectile>();
            projs.Add(newProj);
            //Returns The Fresh Projectile Component
            return newProj;
        }
    }
}
