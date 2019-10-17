using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    [SerializeField] GameUI gameUI;
    public static string activeWeaponType;

    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;

    GameObject activeGun;

    [SerializeField]
    Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        activeWeaponType = Constants.Pistol;// initialize starting gun as the pistol
        activeGun = pistol;
    }

    private void loadWeapon(GameObject weapon)// notifies you when you change a weapon and will set the active gun to the one you switched to
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);
        weapon.SetActive(true);
        activeGun = weapon;
        gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));// updates ammo cost when guns are switched
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))// each if statement checks to see which number is pressed and loads the weapon associated to the number and activates that weapon then puts that weapon to static
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("2"))
        {
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
            gameUI.UpdateReticle();
        }

        else if (Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
            gameUI.UpdateReticle();
        }
    }
    public GameObject GetActiveWeapon()// returns active gun so the scripts can read the peice of information
    {
        return activeGun;
    }
}
