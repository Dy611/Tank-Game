using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Profiles;
using TMPro;
using UnityEngine.UI;

public class CustomizeMode : MonoBehaviour
{
    [SerializeField]
    private ModeProfile modeProfile;

    [SerializeField]
    private TMP_Text winningScoreText, respawnDelayText;

    [SerializeField]
    private Toggle randomTanksToggle, randomWeaponsToggle, randomProjectilesToggle, randomDestructiblesToggle;

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

        winningScoreText.text = modeProfile.winningScore.ToString("0.0");
        respawnDelayText.text = modeProfile.respawnDelay.ToString("0.0");
        randomTanksToggle.isOn = modeProfile.randomTanks;
        randomWeaponsToggle.isOn = modeProfile.randomWeapons;
        randomProjectilesToggle.isOn = modeProfile.randomProjectiles;
        randomDestructiblesToggle.isOn = modeProfile.randomDestructibles;
    }

    public void IncrementWinningScore()
    {
        modeProfile.winningScore = Mathf.Clamp(++modeProfile.winningScore, 0, 20);
        UpdateText(modeProfile.winningScore, winningScoreText);
    }

    public void DecrementWinningScore()
    {
        modeProfile.winningScore = Mathf.Clamp(--modeProfile.winningScore, 0, 20);
        UpdateText(modeProfile.winningScore, winningScoreText);
    }

    public void IncrementRespawnDelay()
    {
        modeProfile.respawnDelay = Mathf.Clamp(modeProfile.respawnDelay += 0.1f, 0, 10);
        UpdateText(modeProfile.respawnDelay, respawnDelayText);
    }

    public void DecrementRespawnDelay()
    {
        modeProfile.respawnDelay = Mathf.Clamp(modeProfile.respawnDelay -= 0.1f, 0, 10);
        UpdateText(modeProfile.respawnDelay, respawnDelayText);
    }

    private void UpdateText(int newNumber, TMP_Text textElement)
    {
        textElement.text = newNumber.ToString("0.0");
    }

    private void UpdateText(float newNumber, TMP_Text textElement)
    {
        textElement.text = newNumber.ToString("0.0");
    }

    public void RandomTanks(bool setBool)
    {
        modeProfile.randomTanks = setBool;
    }

    public void RandomWeapons(bool setBool)
    {
        modeProfile.randomWeapons = setBool;
    }

    public void RandomProjectiles(bool setBool)
    {
        modeProfile.randomProjectiles = setBool;
    }

    public void RandomDestructibles(bool setBool)
    {
        modeProfile.randomDestructibles = setBool;
    }
}