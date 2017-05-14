using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponButton : MonoBehaviour {
    IInput inputOr;
    void Start()
    {
        inputOr = InputManager.instance.getInput();

        if (!(inputOr is InputMobile))
        {
            gameObject.SetActive(false);
        }
    }

    public void ChangeWeapon()
    {
        WeaponManager.instance.ChangeWeapon();
    }

}
