using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScreenSpaceUIScript : MonoBehaviour {
    
    public EnemyHealth enemyScript;

    public Canvas canvas;
    public Pool HealthBarPoolManager;

    public float healthPanelOffset = 1f;
    public GameObject healthPanel;
    private Slider healthSlider;

    void Start()
    {
        enemyScript = GetComponent<EnemyHealth>();
        healthPanel = HealthBarPoolManager.Spawn().gameObject;
        healthSlider = healthPanel.GetComponentInChildren<Slider>();
        //healthPanel.transform.SetParent(canvas.transform, false);
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
        if (healthPanel) healthPanel.GetComponent<PoolObject>().Recycl();
    }
}
