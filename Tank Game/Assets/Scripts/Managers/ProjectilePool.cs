using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame;

public class ProjectilePool : MonoBehaviour
{
    private static readonly List<Projectile> projs = new List<Projectile>();
    private static GameObject projPooler;

    private void Awake()
    {
        projPooler = gameObject;
        foreach (Projectile proj in Resources.FindObjectsOfTypeAll<Projectile>())
            projs.Add(proj);
    }

    public static Projectile GetProjectile()
    {
        for (int i = 0; i < projs.Count; i++)
            if (projs[i].canUse)
            {
                projs[i].canUse = false;
                return projs[i];
            }

        return CreateAnotherProjectile();
    }

    private static Projectile CreateAnotherProjectile()
    {
        GameObject newProjObj = new GameObject("Projectile" + (projs.Count + 1));
        newProjObj.transform.parent = projPooler.transform;
        newProjObj.AddComponent<SpriteRenderer>();
        newProjObj.AddComponent<CircleCollider2D>();
        newProjObj.AddComponent<Rigidbody2D>();
        Projectile newProj = newProjObj.AddComponent<Projectile>();
        projs.Add(newProj);
        return newProj;
    }
}
