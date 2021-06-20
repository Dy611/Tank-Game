using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Managers
{
    public class DestructiblePool : MonoBehaviour
    {
        /// <summary>
        /// Pooled List Of All Destructibles In The Scene
        /// </summary>
        private static readonly List<Destructible> destructibles = new List<Destructible>();

        private void Start()
        {
            foreach(Destructible destructible in Resources.FindObjectsOfTypeAll<Destructible>())
            {
                if(destructible.gameObject.layer == 6)
                {
                    destructibles.Add(destructible);
                    destructible.transform.parent = transform;
                }

                destructible.health.OnDeath += RespawnObject;
            }
        }

        //Clears Old References On Scene Change
        private void OnDisable()
        {
            destructibles.Clear();
        }

        private void RespawnObject()
        {
            for(int i = 0; i < destructibles.Count; i++)
            {
                if(!destructibles[i].gameObject.activeInHierarchy)
                {
                    StartCoroutine(ResetObject(destructibles[i].gameObject, destructibles[i].respawnTime));
                    break;
                }
            }

            foreach(Destructible destructible in destructibles)
            {
                if(!destructible.gameObject.activeInHierarchy && destructible.respawn && !destructible.respawning)
                {
                    destructible.respawning = true;
                    StartCoroutine(ResetObject(destructible.gameObject, destructible.respawnTime));
                }
            }
        }

        private IEnumerator ResetObject(GameObject obj, float respawnTime)
        {
            yield return new WaitForSeconds(respawnTime);
            obj.SetActive(true);
        }
    }
}