using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;//speed of gun fire
    public Ammo ammo;// tracks gun ammo
    public AudioClip liveFire;//stores references to liveFire sound effects
    public AudioClip dryFire;// stores references to dryFire sound Effects
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
        if (ammo.HasAmmo(tag))// checks to see if player has any ammo left
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);// if player has ammo left plays liveFire sound
            ammo.ConsumeAmmo(tag);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);// if not plays dryFire sound
        }
        GetComponentInChildren<Animator>().Play("Fire");
    }
}

