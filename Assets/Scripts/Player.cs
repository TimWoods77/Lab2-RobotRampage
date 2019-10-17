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
                gameUI.SetArmorText(armor);// updates the armor as it takes damage
                return;
            }
            armor = 0;
            gameUI.SetArmorText(armor);
        }

        health -= healthDamage;
        gameUI.SetHealthText(health);// updates the health while it changes

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
        gameUI.SetPickUpText("Health picked up + 50 Health");// shows pickup text alert
        gameUI.SetHealthText(health);// updates health UI
    }

    private void pickupArmor()
    {
        armor += 15;
        gameUI.SetPickUpText("Armor picked up + 15 armor");// shows the pickup text alert
        gameUI.SetArmorText(armor);// updates armor UI
    }

    // 2 
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        gameUI.SetPickUpText("Assault rifle ammo picked up + 50 ammo");// notifies player of what ammunition was picked up

        if (gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle)// checks to see if active gun was the assault rifle before setting ammo count
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
        }
    }

    private void pickupPisolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
        gameUI.SetPickUpText("Pistol ammo picked up + 20 ammo");

        if (gunEquipper.GetActiveWeapon().tag == Constants.Pistol)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
        }
    }

    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
        gameUI.SetPickUpText("Shotgun ammo picked up + 10 ammo");

        if (gunEquipper.GetActiveWeapon().tag == Constants.Shotgun)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Shotgun));
        }
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


