﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameUI gameUI;
    public GameObject player;
    public int score;
    public int waveCountdown;
    public bool isGameOver;
    private static Game singleton;
    [SerializeField]
    RobotSpawn[] spawns;// array of teleporters that spawn robots each wave
    public int enemiesLeft;// tracks how many robots are still alive

    // 1
    void Start()
    {
        singleton = this;// inializes singleton
        StartCoroutine("increaseScoreEachSecond");// starts to increase score each second
        isGameOver = false;// initializes all the variables to their starting values
        Time.timeScale = 1; waveCountdown = 30;
        enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");// starts updatewave timer
        SpawnRobots();// spawns the robots
    }
    // 2
    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();     enemiesLeft++;
        }
        gameUI.SetEnemyText(enemiesLeft);
    }

    private IEnumerator updateWaveTimer()
    {
        while (!isGameOver)//checks to see if gameover flag is set
        {
            yield return new WaitForSeconds(1f);
            waveCountdown--;
            gameUI.SetWaveText(waveCountdown);// if gameover flag is not set it will pause for a second before decrementing waveCountdown

            // Spawn next wave and restart count down 
            if (waveCountdown == 0)// checks to see if countdown hits 0
            {
                SpawnRobots();// spawns robots if countdown reaches 0
                waveCountdown = 30;// resets countdown
                gameUI.ShowNewWaveText();// lets player know a new wave of Robots are on the way
            }
        }
    }

    public static void RemoveEnemy()// called when robots are killed
    {
        singleton.enemiesLeft--;// removes one robot from enemy count and updates the UI
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);
        // Give player bonus for clearing the wave before timer is done 
        if (singleton.enemiesLeft == 0)// checks to see if no enemies are left
        {
            singleton.score += 50;// adds a bonus score of 50 points to the player
            singleton.gameUI.ShowWaveClearBonus();
        }
    }

    public void AddRobotKillToScore()// gives player points when they kill a robot
    {
        score += 10; gameUI.SetScoreText(score);
    }

    IEnumerator increaseScoreEachSecond()// A coroutine that updates the score every second
    { while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score += 1; gameUI.SetScoreText(score);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
