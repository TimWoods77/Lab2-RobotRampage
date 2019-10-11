using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pickups;// stores all pickup types

    // 1 
    void spawnPickup()
    {
        // Instantiate a random pickup   
        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;// sets position to pickup spawn
        pickup.transform.parent = transform;
    }

    // 2 
    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);// waits 20 seconds to respawn pickups
        spawnPickup();
    }

    // 3 
    void Start()
    {
        spawnPickup();// spawns a pickup as soon as the game begins
    }

    // 4 
    public void PickupWasPickedUp()
    {
        StartCoroutine("respawnPickup");// starts the coroutine to respawn when player picks something up
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
