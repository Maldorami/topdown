using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberDamage : MonoBehaviour
{
	ParticleSystem partSystem;
    public GameObject Body;
    public float damage;

    void Awake()
    {
        Transform tmp = transform.FindChild("BomberParticleSystem");
		partSystem = tmp.gameObject.GetComponent<ParticleSystem> ();
        tmp = transform.FindChild("Body");
        Body = tmp.gameObject;
    }

    private void OnDisable()
    {
        Body.SetActive(true);
    }

    public void Attack(bool condition)
    {
        StartCoroutine("BOOM", condition);
    }

    IEnumerator BOOM(bool condition)
    {
        Body.SetActive(false);
		partSystem.Play ();
        
        if (condition)
        {
            Debug.Log("<color=green>BomberAttack!</color>");
            PlayerManager.instance.attackPlayer(damage);
        }
        
        yield return new WaitForSeconds(.2f);

		gameObject.GetComponent<EnemyHealth>().health = 0;
    }
}
