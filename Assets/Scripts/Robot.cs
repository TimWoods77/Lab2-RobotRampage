using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    GameObject missileprefab;// missile prefab 

    [SerializeField]// allows us to access robots from the inspector but not from scripts
    private string robotType;// type of robot

    public int health;// amount of damage robot can take before dying
    public int range;// distance gun can fire
    public float fireRate;// how fast gun can fire
    public Transform missileFireSpot;
    UnityEngine.AI.NavMeshAgent agent;// reference to navmesh agent component
    public Animator robot;

    private Transform player;// what robot will track
    private float timeLastFired;

    private bool isDead;// tracks if robot is dead or alive

    // Start is called before the first frame update
    void Start()
    {
        // 1   
        isDead = false;// by default all robots are alive
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // sets agents values to navmesh
        player = GameObject.FindGameObjectWithTag("Player").transform;// sets player's values to navmesh
    }
    // Update is called once per frame 

    void Update()
    {
        // 2   
        if (isDead)// checks to see if all robots are dead and not zombiefied before continuing
        {
            return;
        }
        // 3 
        transform.LookAt(player);// makes robot face player
        // 4 
        agent.SetDestination(player.position);// tells robot to use the navmesh to find player
        // 5 
        if (Vector3.Distance(transform.position, player.position) < range// checks to see if robot is in firing range and if there's been enough time between shots to fire again.
            && Time.time - timeLastFired > fireRate)
        {
            // 6  
            timeLastFired = Time.time; fire();// logs a message to the console for the time being
        }
    }
    private void fire()
    {
        GameObject missile = Instantiate(missileprefab);// makes a new missileprefab and sets it's position and rotation to the robot's firing spot.
        missile.transform.position = missileFireSpot.transform.position;
        missile.transform.rotation = missileFireSpot.transform.rotation;
        robot.Play("Fire");
    }

    // 1 
    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        } 
        health -= amount; 
        if (health <= 0)
        {
            isDead = true;
            robot.Play("Die");
            StartCoroutine("DestroyRobot");
        }
    }
    // 2
    IEnumerator DestroyRobot()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

}
