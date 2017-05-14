using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public static WeaponManager instance;

    [SerializeField]
    private Weapon[] _weapons;

    private int _currentWeapon = 0;


	void Awake () {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);


        for (int i = 1; i < _weapons.Length; i++)
        {
            _weapons[i].Desactivate();
        }
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapon();
        }

        if (Input.GetKeyDown("2"))
        {
            ChangeWeapon(2);
        }
    }

    public void ChangeWeapon()
    {
        _weapons[_currentWeapon].Desactivate();
        _currentWeapon = (_currentWeapon + 1) % _weapons.Length;
        _weapons[_currentWeapon].Activate();
    }

    public void ChangeWeapon(int value)
    {
        if (value < _weapons.Length)
        {
            _weapons[_currentWeapon].Desactivate();
            _currentWeapon = value;
            _weapons[_currentWeapon].Activate();
        }
    }

    public void SetDefaultGun()
    {
            _weapons[_currentWeapon].Desactivate();
            _currentWeapon = 0;
            _weapons[_currentWeapon].Activate();
    }

    public GameObject getCurrentWeaponAsGameObject()
    {
        return _weapons[_currentWeapon].gameObject;
    }

    public Weapon getCurrentWeaponAsWeapon()
    {
        return _weapons[_currentWeapon];
    }
}
