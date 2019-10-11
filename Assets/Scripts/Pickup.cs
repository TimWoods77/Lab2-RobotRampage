using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int type;// type of pickup

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Player>() != null && collider.gameObject.tag == "Player")
        {
            GetComponentInParent<PickupSpawn>().PickupWasPickedUp();// restarts spawn timer for pickups after player interacts with them
            collider.gameObject.GetComponent<Player>().PickUpItem(type); Destroy(gameObject);
        }
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
