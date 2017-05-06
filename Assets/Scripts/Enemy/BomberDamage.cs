using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberDamage : MonoBehaviour
{

    GameObject particleSystem;
    GameObject Body;

    float timer;

    public float damage;

    EnemyScreenSpaceUIScript ess;

    void Start()
    {
        Transform tmp = transform.Find("BomberParticleSystem");
        particleSystem = tmp.gameObject;

        tmp = transform.Find("Body");
        Body = tmp.gameObject;

        ess = gameObject.GetComponent<EnemyScreenSpaceUIScript>();

    }

    public void Attack(bool condition)
    {
        StartCoroutine("BOOM", condition);
    }

    IEnumerator BOOM(bool condition)
    {
        Body.SetActive(false);
        particleSystem.SetActive(true);
        
        if (condition)
        {
            Debug.Log("<color=green>BomberAttack!</color>");
            PlayerManager.instance.attackPlayer(damage);
        }

        if (ess) ess.DisableHealthPanel();

        yield return new WaitForSeconds(1f);        
        Destroy(gameObject);
    }
}
