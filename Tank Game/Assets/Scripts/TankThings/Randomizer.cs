using UnityEngine;
using TankGame.Profiles;

namespace TankGame
{
    public class Randomizer : MonoBehaviour
    {
        private static TankProfile[] tankProfiles;
        private static WeaponProfile[] weaponProfiles;
        private static ProjectileProfile[] projectileProfiles;
        private static DestructibleProfile[] destrucProfiles;

        private void Awake()
        {
            tankProfiles = (TankProfile[])Resources.FindObjectsOfTypeAll(typeof(TankProfile));
            weaponProfiles = (WeaponProfile[])Resources.FindObjectsOfTypeAll(typeof(WeaponProfile));
            projectileProfiles = (ProjectileProfile[])Resources.FindObjectsOfTypeAll(typeof(ProjectileProfile));
            destrucProfiles = (DestructibleProfile[])Resources.FindObjectsOfTypeAll(typeof(DestructibleProfile));
        }

        public static TankProfile GetTankProfile()
        {
            int num = RandomNum(tankProfiles.Length);
            return tankProfiles[num];
        }

        public static WeaponProfile GetWeaponProfile()
        {
            int num = RandomNum(weaponProfiles.Length);
            return weaponProfiles[num];
        }

        public static ProjectileProfile GetProjectileProfile()
        {
            int num = RandomNum(projectileProfiles.Length);
            return projectileProfiles[num];
        }

        public static DestructibleProfile GetDestructibleProfile()
        {
            int num = RandomNum(destrucProfiles.Length);
            return destrucProfiles[num];
        }

        public static void ThrowError(string objName)
        {
            Debug.LogError("Object: " + objName + " Couldn't Be Assigned A Profile");
        }

        private static int RandomNum(int max)
        {
            return Random.Range(0, max);
        }
    }
}