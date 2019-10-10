using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;

    [SerializeField]
    private int pistolAmmo = 20;// tracks guns ammo count
    [SerializeField]
    private int shotgunAmmo = 10;
    [SerializeField]
    private int assaultRifleAmmo = 50;

    public Dictionary<string, int> tagToAmmo;// dictonary type for string and int's which maps a gun type and it's ammo count

    void Awake()// initializes the use of the dictionary
    {
        tagToAmmo = new Dictionary<string, int>
        {
            {
                Constants.Pistol, pistolAmmo},
            { Constants.Shotgun, shotgunAmmo },
            { Constants.AssaultRifle, assaultRifleAmmo },
        };
    }

    public void AddAmmo(string tag, int ammo)// adds ammo to the appropriate gun if gun is unrecognized it'll log an error
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }
        tagToAmmo[tag] += ammo;
    }

    // Returns true if gun has ammo or false if it has no ammo
    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        } 
   return tagToAmmo[tag] > 0;
    }

    public int GetAmmo(string tag)// return bullet count for a gun type
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        return tagToAmmo[tag];
    }

    public void ConsumeAmmo(string tag)//checks for appropriate tags if found the appropriate ammo it'll subtract a bullet
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        tagToAmmo[tag]--;
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
