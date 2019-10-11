using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;// players remaining health
    public int armor;// extra 50% armor
    public GameUI gameUI;// references gameUI script
    private GunEquipper gunEquipper;// references gunEquipper script
    private Ammo ammo;// references ammo class

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();// gets ammo attached to the player
        gunEquipper = GetComponent<GunEquipper>();// gets gunequipper attached to the player
    }

    public void TakeDamage(int amount)// takes the incoming damage taken in and reduces it based on amount of player armor
    {
        int healthDamage = amount;

        if (armor > 0)
        {
            int effectiveArmor = armor * 2; // no armor player takes damage
            effectiveArmor -= healthDamage;

            // If there is still armor, don't need to process
            // health damage
            if (effectiveArmor > 0)
            {
                armor = effectiveArmor / 2;
                return;
            }

            armor = 0;
        }

        health -= healthDamage;
        Debug.Log("Health is " + health);

        if (health <= 0)// checks to see if player health reached zero if so game over.
        {
            Debug.Log("GameOver");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 1 
    private void pickupHealth()
    {
        health += 50;

        if (health > 200)
        {
            health = 200;
        }
    }

    private void pickupArmor()
    {
        armor += 15;
    }

    // 2 
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
    }

    private void pickupPisolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
    }

    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
    }

    public void PickUpItem(int pickupType)// takes a int that represents the type of item being picked up
    {
        switch (pickupType)
        {
            case Constants.PickUpArmor:// references the ID's of all the pickups
                pickupArmor();
                break;
            case Constants.PickUpHealth:
                pickupHealth();
                break;
            case Constants.PickUpAssaultRifleAmmo:
                pickupAssaultRifleAmmo();
                break;
            case Constants.PickUpPistolAmmo:
                pickupPisolAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                pickupShotgunAmmo();
                break;
            default:
                Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }
    }
}


