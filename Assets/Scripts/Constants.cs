﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants 
{
    //scenes
    public const string SceneBattle = "Battle";
    public const string SceneMenu = "MainMenu";

    //Gun Types
    public const string Pistol = "Pistol";
    public const string AssaultRifle = "AssaultRifle";
    public const string Shotgun = "Shotgun";

    //Robot Types
    public const string RedRobot = "RedRobot";
    public const string BlueRobot = "BlueRobot";
    public const string YellowRobot = "YellowRobot";

    //Pickup Types
    public const int PickUpPistolAmmo = 1;
    public const int PickUpAssaultRifleAmmo = 2;
    public const int PickUpShotgunAmmo = 3;
    public const int PickUpHealth = 4;
    public const int PickUpArmor = 5;

    //Misc
    public const string Game = "Game";
    public const float CameraDefaultZoom = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static readonly int[] AllPickupTypes = new int[5] // keeps track of all the pickups
    {
        PickUpPistolAmmo,
        PickUpAssaultRifleAmmo,
        PickUpShotgunAmmo,
        PickUpHealth,
        PickUpArmor
    };
}
