using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    public Slider playerHealthBar;
    public Text waveText;


    void Update()
    {
        playerHealthBar.value = PlayerManager.instance.playerHealth / (float)PlayerManager.instance.maxPlayerHealth;

        waveText.text = "Wave: \"" + SpawnManager.instance.waves[SpawnManager.instance.NextWave - 1].name + "\" -> " + (SpawnManager.instance.NextWave).ToString() + "/" + SpawnManager.instance.waves.Length.ToString();
    }
}
