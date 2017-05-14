﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScreenSpaceUIScript : MonoBehaviour {
    
    private EnemyHealth enemyScript;

    public Canvas canvas;
    public GameObject healthPrefab;

    public float healthPanelOffset = 1f;
    public GameObject healthPanel;
    private Slider healthSlider;

    void Start()
    {
        enemyScript = GetComponent<EnemyHealth>();
        healthPanel = Instantiate(healthPrefab) as GameObject;
        healthPanel.transform.SetParent(canvas.transform, false);
        
        healthSlider = healthPanel.GetComponentInChildren<Slider>();
    }

    void Update()
    {
        healthSlider.value = enemyScript.health / (float)enemyScript.MaxHealth;

        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + healthPanelOffset);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        if(healthPanel)
        healthPanel.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
    }

    public void DisableHealthPanel()
    {
        if (healthPanel) Destroy(healthPanel);
    }
}
