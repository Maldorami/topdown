using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberDamage : MonoBehaviour
{
    GameObject partSystem;
    public GameObject Body;
    public float damage;

    void Awake()
    {
        Transform tmp = transform.FindChild("BomberParticleSystem");
        partSystem = tmp.gameObject;
        tmp = transform.FindChild("Body");
        Body = tmp.gameObject;
    }

    private void OnDisable()
    {
        Body.SetActive(true);
        partSystem.SetActive(false);
    }

    public void Attack(bool condition)
    {
        gameObject.GetComponent<EnemyHealth>().health = 0;
        StartCoroutine("BOOM", condition);
    }

    IEnumerator BOOM(bool condition)
    {
        Body.SetActive(false);
        partSystem.SetActive(true);
        
        if (condition)
        {
            Debug.Log("<color=green>BomberAttack!</color>");
            PlayerManager.instance.attackPlayer(damage);
        }
        
        yield return new WaitForSeconds(1f);
    }
}
