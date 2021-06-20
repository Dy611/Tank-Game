using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using TankGame.Profiles;

namespace TankGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private ModeProfile modeProfile;

        [SerializeField]
        private TMP_Text score1, score2, winningScoreText, winningText;

        [SerializeField]
        private GameObject winningButton;

        private int p1score, p2score, winningScore;
        private float respawnTime;

        private static GameObject[] players;
        private static GameObject[] spawnPositions;

        public delegate void GameOver();
        public static event GameOver OnGameOver;

        private void Awake()
        {
            winningText.text = "";
            winningButton.SetActive(false);

            players = GameObject.FindGameObjectsWithTag("Player");
            spawnPositions = GameObject.FindGameObjectsWithTag("SpawnPosition");

            foreach (GameObject player in players)
            {
                player.GetComponent<Health>().OnDeath += UpdateScore;
            }

            winningScore = modeProfile.winningScore;
            respawnTime = modeProfile.respawnDelay;
            winningScoreText.text = "Winning Score: " + winningScore;

            if (modeProfile.randomTanks)
                RandomizeTanks();

            if (modeProfile.randomWeapons)
                RandomizeWeapons();

            if (modeProfile.randomProjectiles)
                RandomizeProjectiles();

            if (modeProfile.randomDestructibles)
                RandomizeDestructibles();

            InitializePlayerTanks();
        }

        private void RandomizeTanks()
        {

        }

        private void RandomizeWeapons()
        {

        }

        private void RandomizeProjectiles()
        {

        }

        private void RandomizeDestructibles()
        {

        }

        private void InitializePlayerTanks()
        {

        }

        private void UpdateScore()
        {
            foreach(GameObject player in players)
            {
                if (!player.activeInHierarchy && player.name == "Player2")
                {
                    p1score++;
                }
                else if(!player.activeInHierarchy && player.name == "Player1")
                {
                    p2score++;
                }
            }

            score1.text = "Player 1: " + p1score;
            score2.text = "Player 2: " + p2score;
            
            if(p1score >= winningScore)
                GameWon(1);
            else if(p2score >= winningScore)
                GameWon(2);
        }

        private void GameWon(int winningPlayer)
        {
            OnGameOver?.Invoke();
            Time.timeScale = 0;
            winningText.text = "Player " + winningPlayer + " Wins!";
            winningButton.SetActive(true);
        }

        public void SpawnPlayer()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].activeInHierarchy)
                {
                    int highestIndex = 0;
                    float highestDist = Vector2.Distance(spawnPositions[0].transform.position, players[i].transform.position);
                    for (int j = 0; j < spawnPositions.Length; j++)
                    {
                        float currDist = Vector2.Distance(spawnPositions[j].transform.position, players[i].transform.position);
                        if (currDist > highestDist)
                        {
                            highestDist = currDist;
                            highestIndex = j;
                        }
                    }

                    for (int k = 0; k < players.Length; k++)
                    {
                        if (!players[k].activeInHierarchy)
                        {
                            StartCoroutine(DelaySpawn(respawnTime, highestIndex, k));
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private IEnumerator DelaySpawn(float timer, int distanceIndex, int playerIndex)
        {
            yield return new WaitForSeconds(timer);
            players[playerIndex].transform.position = spawnPositions[distanceIndex].transform.position;
            players[playerIndex].transform.rotation = Quaternion.identity;
            players[playerIndex].SetActive(true);
        }
    }
}