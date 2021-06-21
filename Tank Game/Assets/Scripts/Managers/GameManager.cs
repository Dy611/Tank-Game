using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TankGame.Profiles;

namespace TankGame.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private ModeProfile modeProfile;
        [SerializeField]
        private TMP_Text score1;
        [SerializeField]
        private TMP_Text score2;
        [SerializeField]
        private TMP_Text winningScoreText;
        [SerializeField]
        private TMP_Text winningText;
        [SerializeField]
        private GameObject winningButton;

        private int p1score;
        private int p2score;
        private int winningScore;
        private float respawnTime;

        private static Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();
        private static GameObject[] spawnPositions;

        public delegate void GameOver();
        public static event GameOver OnGameOver;
        #endregion Variables

        #region Initialization
        private void Awake()
        {
            InitializeMode();
        }

        //Clears Old References On Scene Change
        private void OnDisable()
        {
            players.Clear(); 
            Array.Clear(spawnPositions, 0, spawnPositions.Length);
        }

        private void InitializeMode()
        {
            //Finds Player Objects And Assigns Them To A Dictionary
            GameObject[] playersGO = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < playersGO.Length; i++)
            {
                players.Add(playersGO[i].name, playersGO[i]);
                players[playersGO[i].name].GetComponent<Health>().OnDeath += UpdateScore;
            }

            //Assigns Tank Components To An Array
            Tank[] tanks = new Tank[playersGO.Length];
            for (int i = 0; i < playersGO.Length; i++)
            {
                tanks[i] = playersGO[i].GetComponent<Tank>();
            }

            //Finds All Possible Spawn Positions On The Map
            spawnPositions = GameObject.FindGameObjectsWithTag("SpawnPosition");

            //Sets The Game Rules UI
            winningText.text = "";
            winningButton.SetActive(false);
            winningScore = modeProfile.winningScore;
            winningScoreText.text = "Winning Score: " + winningScore;

            //Sets Respawn Time To Match The Mode Profile
            respawnTime = modeProfile.respawnDelay;

            //Randomizes Game Based On Set Mode Rules
            if (modeProfile.randomTanks)
                Randomize(tanks);

            if (modeProfile.randomWeapons)
                Randomize(FindObjectsOfType<Weapon>());

            if (modeProfile.randomProjectiles)
                RandomizeProjectiles();

            if (modeProfile.randomDestructibles)
                Randomize(FindObjectsOfType<Destructible>());

            InitializeTanks();
        }

        /// <summary>
        /// Sets The Players Tanks To Match The Mode Settings
        /// </summary>
        private void InitializeTanks()
        {
            //Player 1
            Weapon weapon = players["Player 1"].GetComponentInChildren<Weapon>();
            players["Player 1"].GetComponent<Tank>().tProfile = ProfilesManager.tankProfiles[modeProfile.player1Tank];
            weapon.wProfile = ProfilesManager.weaponProfiles[modeProfile.player1Weapon];
            weapon.pProfile = ProfilesManager.projectileProfiles[modeProfile.player1Projectile];

            //Player 2
            weapon = players["Player 2"].GetComponentInChildren<Weapon>();
            players["Player 2"].GetComponent<Tank>().tProfile = ProfilesManager.tankProfiles[modeProfile.player2Tank];
            weapon.wProfile = ProfilesManager.weaponProfiles[modeProfile.player2Weapon];
            weapon.pProfile = ProfilesManager.projectileProfiles[modeProfile.player2Projectile];
        }
        #endregion Initialization

        #region Randomization
        private void Randomize<T>(T[] thing) where T : IRandomizeAble
        {
            for (int i = 0; i < thing.Length; i++)
                thing[i].randomize();
        }

        private void RandomizeProjectiles()
        {
            foreach (Weapon weapon in FindObjectsOfType<Weapon>())
                weapon.randomizeProj = true;
        }
        #endregion Randomization

        #region Rules Control
        private void UpdateScore()
        {
            if (players["Player 1"].activeInHierarchy)
                p1score++;
            else
                p2score++;

            score1.text = "Player 1: " + p1score;
            score2.text = "Player 2: " + p2score;

            if (p1score >= winningScore)
                GameWon();
            else if (p2score >= winningScore)
                GameWon();
        }

        private void GameWon()
        {
            OnGameOver?.Invoke();
            Time.timeScale = 0;

            if (players["Player 1"].activeInHierarchy)
                winningText.text = players["Player 1"].name + " Wins!";
            else
                winningText.text = players["Player 2"].name + " Wins!";

            winningButton.SetActive(true);
        }

        public void SpawnPlayer()
        {
            if (players["Player 1"].activeInHierarchy)
                Respawn(players["Player 1"], players["Player 2"]);
            else if (players["Player 2"].activeInHierarchy)
                Respawn(players["Player 2"], players["Player 1"]);
        }
        private void Respawn(GameObject alivePlayer, GameObject deactivatedPlayer)
        {
            int highestIndex = 0;
            float highestDist = Vector2.Distance(spawnPositions[0].transform.position, alivePlayer.transform.position);
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                float currDist = Vector2.Distance(spawnPositions[i].transform.position, alivePlayer.transform.position);
                if (currDist > highestDist)
                {
                    highestDist = currDist;
                    highestIndex = i;
                }
            }
            StartCoroutine(DelaySpawn(respawnTime, highestIndex, deactivatedPlayer));
        }

        private IEnumerator DelaySpawn(float timer, int distanceIndex, GameObject player)
        {
            yield return new WaitForSeconds(timer);
            player.transform.position = spawnPositions[distanceIndex].transform.position;
            player.transform.rotation = Quaternion.identity;
            player.SetActive(true);
        }
    }
    #endregion Rules Control
}