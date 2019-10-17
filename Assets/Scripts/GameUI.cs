using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// allows us to access the base unity UI classes

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text armorText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text pickupText;
    [SerializeField]
    private Text waveText;
    [SerializeField]
    private Text enemyText;
    [SerializeField]
    private Text waveClearText;
    [SerializeField]
    private Text newWaveText;
    [SerializeField]
    Player player;
    [SerializeField]
    Sprite redReticle;// Allows you to convey information from C# runtime and particular classes 
    [SerializeField]
    Sprite yellowReticle;// Sprite is an imported texture that is meant to be used in 2D and UI games
    [SerializeField]
    Sprite blueReticle;
    [SerializeField]
    Image reticle;// image is displaying the sprites to the screen

    public void UpdateReticle()
    {
        switch (GunEquipper.activeWeaponType)// changes sprite to reflect active gun
        {
            case Constants.Pistol: reticle.sprite = redReticle; break;
            case Constants.Shotgun: reticle.sprite = yellowReticle; break;
            case Constants.AssaultRifle:
                reticle.sprite = blueReticle;
                break;
            default:
                return;
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
