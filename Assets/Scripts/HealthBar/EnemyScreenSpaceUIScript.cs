using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScreenSpaceUIScript : MonoBehaviour {
    
    float healthPanelOffset = 1f;
    Slider healthSlider;

    public EnemyHealth enemyScript;
    public GameObject target;

    Vector3 reset;
    public bool alreadySet = false;

    private void Start()
    {
        healthSlider = gameObject.GetComponent<Slider>();
        reset = transform.position;
    }


    void Update()
    {
        if (alreadySet)
        {
            healthSlider.value = enemyScript.health / (float)enemyScript.MaxHealth;

            Vector3 worldPos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z + healthPanelOffset);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
            
            transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);

            if (enemyScript.health <= 0)
            {
                DisableHealthPanel();
            }
       }
    }

    public void DisableHealthPanel()
    {
        gameObject.GetComponent<PoolObject>().Recycl();
        transform.position = reset;
        alreadySet = false;
    }

    public void SetTarget(GameObject enemy)
    {
        target = enemy;
        enemyScript = enemy.GetComponent<EnemyHealth>();
        alreadySet = true;

        //Debug.LogError("<color=red>ENEMIGO SETEADO EN HEALTHBAR!!</color>");

    }
}
