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