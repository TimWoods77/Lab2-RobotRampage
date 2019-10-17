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

    // 1 
    void Start()
    {
        SetArmorText(player.armor);// Initializes the player health and ammunition text
        SetHealthText(player.health);
    }

    // 2 
    public void SetArmorText(int armor)//  This, and the rest of the methods, is simply a setter that sets the related text values. 
    {
        armorText.text = "Armor: " + armor;
    }

    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }

    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }

    public void SetScoreText(int score)
    {
        scoreText.text = "" + score;
    }

    public void SetWaveText(int time)
    {
        waveText.text = "Next Wave: " + time;
    }

    public void SetEnemyText(int enemies)
    {
        enemyText.text = "Enemies: " + enemies;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1 
    public void ShowWaveClearBonus()// enables the wave clear text when you pass the wave then resets it
    {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("hideWaveClearBonus");
    }

    // 2 
    IEnumerator hideWaveClearBonus()// waits 4 seconds to disable the text and hide it
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<Text>().enabled = false;
    }

    // 3
    public void SetPickUpText(string text)
    {
        pickupText.GetComponent<Text>().enabled = true;
        pickupText.text = text;
        // Restart the Coroutine so it doesn’t end early  
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }

    // 4 
    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.GetComponent<Text>().enabled = false;
    }

    // 5
    public void ShowNewWaveText()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;
    }

    // 6
    IEnumerator hideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<Text>().enabled = false;
    }
}
