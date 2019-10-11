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

   
}


