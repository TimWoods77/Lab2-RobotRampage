using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] robots;// an array of robots to instantiate
    private int timesSpawned;// tracks spawn cylce for robots
    private int healthBonus = 0;// how much health robots gain each level

    public void SpawnRobot()
    {
        timesSpawned++; healthBonus += 1 * timesSpawned;// spawns robot, sets it's health, then sets the position
        GameObject robot = Instantiate(robots[Random.Range(0, robots.Length)]);
        robot.transform.position = transform.position;
        robot.GetComponent<Robot>().health += healthBonus;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
