using System.Collections;
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
        SpawnRobots();// spawns the robots
    }
    // 2
    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();     enemiesLeft++;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
