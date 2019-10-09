using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;//speed of gun fire
    protected float lastFireTime;// tracks the last time gun was fired

    // Start is called before the first frame update
    void Start()
    {
        lastFireTime = Time.time - 10;// sets lastFireTime to 10 seconds before
    }

    // Update is called once per frame
        protected virtual void Update()
    {

    }
    protected void Fire()
    {
        GetComponentInChildren<Animator>().Play("Fire");// fetches animator controller and tells it to play the fire animation 
    }
}

