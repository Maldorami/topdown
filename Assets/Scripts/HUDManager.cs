using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    public Slider playerHealthBar;
    public Text waveText;

    public Text CurrentWeaponName;
    public Text CurrentWeaponAmmo;

    void Update()
    {
        //Player Health Bar
        playerHealthBar.value = PlayerManager.instance.playerHealth / (float)PlayerManager.instance.maxPlayerHealth;
        waveText.text = "Wave: \"" + SpawnManager.instance.waves[SpawnManager.instance.NextWave - 1].name + "\" -> " + (SpawnManager.instance.NextWave).ToString() + "/" + SpawnManager.instance.waves.Length.ToString();
        //Current Ammo Info
        CurrentWeaponName.text = WeaponManager.instance.getCurrentWeaponAsGameObject().name;
        CurrentWeaponAmmo.text = WeaponManager.instance.getCurrentWeaponAsWeapon().currentAmmo.ToString() + "/" + WeaponManager.instance.getCurrentWeaponAsWeapon().Ammo.ToString();
    }
}
