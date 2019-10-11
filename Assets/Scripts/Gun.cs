using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;//speed of gun fire
    public Ammo ammo;// tracks gun ammo
    public AudioClip liveFire;//stores references to liveFire sound effects
    public AudioClip dryFire;// stores references to dryFire sound Effects
    public float zoomFactor;// controls zoom level
    public int range;// how far the gun can shoot at robots
    public int damage;// how much damage gun causes

    private float zoomFOV;// field of view
    private float zoomSpeed = 6;

    protected float lastFireTime;// tracks the last time gun was fired


    // Start is called before the first frame update
    void Start()
    {
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor;// initializes zoom factor
        lastFireTime = Time.time - 10;
    }

    // Update is called once per frame
    protected virtual void Update()
    {   // Right Click (Zoom)  
        if (Input.GetMouseButton(1))// if player hits right mouse button activates zoom
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            Camera.main.fieldOfView = Constants.CameraDefaultZoom;
        }
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

    private void processHit(GameObject hitObject)// creates a ray and checks to see what the ray hits
    {
        if (hitObject.GetComponent<Player>() != null)
        {
            hitObject.GetComponent<Player>().TakeDamage(damage);
        }
        if (hitObject.GetComponent<Robot>() != null)
        {
            hitObject.GetComponent<Robot>().TakeDamage(damage);// checks to see if hit ray was a robot if so it takes damage
        }
    }
}

