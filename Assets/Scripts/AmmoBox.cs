using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour {

    public float rot;
    public int bulletsToGive;
	
	void Update () {
        gameObject.transform.Rotate(rot * Time.deltaTime, rot * Time.deltaTime, rot * Time.deltaTime);	
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            WeaponManager.instance.getCurrentWeaponAsWeapon().PartialyRefillBulletCarger(bulletsToGive);
            Debug.Log("<color=yellow>"+ WeaponManager.instance.getCurrentWeaponAsGameObject().name +"</color>");
			GetComponent<PoolObject> ().Recycl ();
        }
    }
}
