using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Profiles;
using TMPro;
using UnityEngine.UI;

namespace TankGame
{
    public class CustomModeManager : MonoBehaviour
    {
        [SerializeField]
        private ModeProfile modeProfile;

        [SerializeField]
        private TMP_Text winningScoreText, respawnDelayText, player1TankText, player1WeaponText, player1ProjText, player2TankText, player2WeaponText, player2ProjText;

        [SerializeField]
        private Toggle randomTanksToggle, randomWeaponsToggle, randomProjectilesToggle, randomDestructiblesToggle;

        private void Start()
        {
            winningScoreText.text = modeProfile.winningScore.ToString();
            respawnDelayText.text = modeProfile.respawnDelay.ToString("0.0");

            player1TankText.text = (modeProfile.player1Tank + 1).ToString();
            player1WeaponText.text = (modeProfile.player1Weapon + 1).ToString();
            player1ProjText.text = (modeProfile.player1Projectile + 1).ToString();

            player2TankText.text = (modeProfile.player2Tank + 1).ToString();
            player2WeaponText.text = (modeProfile.player2Weapon + 1).ToString();
            player2ProjText.text = (modeProfile.player2Projectile + 1).ToString();

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
            textElement.text = newNumber.ToString();
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

        public void IncrementPlayer1Tank()
        {
            modeProfile.player1Tank = Mathf.Clamp(++modeProfile.player1Tank, 0, ProfilesManager.tankProfiles.Length - 1);
            UpdateText(modeProfile.player1Tank + 1, player1TankText);
        }

        public void DecrementPlayer1Tank()
        {
            modeProfile.player1Tank = Mathf.Clamp(--modeProfile.player1Tank, 0, ProfilesManager.tankProfiles.Length);
            UpdateText(modeProfile.player1Tank + 1, player1TankText);
        }

        public void IncrementPlayer1Weapon()
        {
            modeProfile.player1Weapon = Mathf.Clamp(++modeProfile.player1Weapon, 0, ProfilesManager.weaponProfiles.Length - 1);
            UpdateText(modeProfile.player1Weapon + 1, player1WeaponText);
        }

        public void DecrementPlayer1Weapon()
        {
            modeProfile.player1Weapon = Mathf.Clamp(--modeProfile.player1Weapon, 0, ProfilesManager.weaponProfiles.Length);
            UpdateText(modeProfile.player1Weapon + 1, player1WeaponText);
        }

        public void IncrementPlayer1Projectile()
        {
            modeProfile.player1Projectile = Mathf.Clamp(++modeProfile.player1Projectile, 0, ProfilesManager.projectileProfiles.Length - 1);
            UpdateText(modeProfile.player1Projectile + 1, player1ProjText);
        }

        public void DecrementPlayer1Projectile()
        {
            modeProfile.player1Projectile = Mathf.Clamp(--modeProfile.player1Projectile, 0, ProfilesManager.projectileProfiles.Length);
            UpdateText(modeProfile.player1Projectile + 1, player1ProjText);
        }
        public void IncrementPlayer2Tank()
        {
            modeProfile.player2Tank = Mathf.Clamp(++modeProfile.player2Tank, 0, ProfilesManager.tankProfiles.Length - 1);
            UpdateText(modeProfile.player2Tank + 1, player2TankText);
        }

        public void DecrementPlayer2Tank()
        {
            modeProfile.player2Tank = Mathf.Clamp(--modeProfile.player2Tank, 0, ProfilesManager.tankProfiles.Length);
            UpdateText(modeProfile.player2Tank + 1, player2TankText);
        }

        public void IncrementPlayer2Weapon()
        {
            modeProfile.player2Weapon = Mathf.Clamp(++modeProfile.player2Weapon, 0, ProfilesManager.weaponProfiles.Length - 1);
            UpdateText(modeProfile.player2Weapon + 1, player2WeaponText);
        }

        public void DecrementPlayer2Weapon()
        {
            modeProfile.player2Weapon = Mathf.Clamp(--modeProfile.player2Weapon, 0, ProfilesManager.weaponProfiles.Length);
            UpdateText(modeProfile.player2Weapon + 1, player2WeaponText);
        }

        public void IncrementPlayer2Projectile()
        {
            modeProfile.player2Projectile = Mathf.Clamp(++modeProfile.player2Projectile, 0, ProfilesManager.projectileProfiles.Length - 1);
            UpdateText(modeProfile.player2Projectile + 1, player2ProjText);
        }

        public void DecrementPlayer2Projectile()
        {
            modeProfile.player2Projectile = Mathf.Clamp(--modeProfile.player2Projectile, 0, ProfilesManager.projectileProfiles.Length);
            UpdateText(modeProfile.player2Projectile + 1, player2ProjText);
        }
    } 
}