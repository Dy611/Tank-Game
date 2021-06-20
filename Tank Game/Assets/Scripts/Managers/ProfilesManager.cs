using UnityEngine;

namespace TankGame.Profiles
{
    public static class ProfilesManager
    {
        public static TankProfile[] tankProfiles;
        public static WeaponProfile[] weaponProfiles;
        public static ProjectileProfile[] projectileProfiles;
        public static DestructibleProfile[] destrucProfiles;

        static ProfilesManager()
        {
            Resources.LoadAll("Profiles", typeof(ScriptableObject));

            tankProfiles = (TankProfile[])Resources.FindObjectsOfTypeAll(typeof(TankProfile));
            weaponProfiles = (WeaponProfile[])Resources.FindObjectsOfTypeAll(typeof(WeaponProfile));
            projectileProfiles = (ProjectileProfile[])Resources.FindObjectsOfTypeAll(typeof(ProjectileProfile));
            destrucProfiles = (DestructibleProfile[])Resources.FindObjectsOfTypeAll(typeof(DestructibleProfile));
        }

        public static T GetProfile<T>(T[] thing) where T : ScriptableObject
        {
            return thing[RandomNum(thing.Length)];
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