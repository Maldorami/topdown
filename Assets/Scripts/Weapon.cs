using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        pistol,
        shotgun,
        machinegun
    }

    [SerializeField]
    private WeaponType type;

    public GameObject bullet;
    private BulletDamage bulletDamage;

    public float speed = 1;


    public float currentAmmo;
    public float Ammo;

    float timer = 0;


    void Start()
    {
        currentAmmo = Ammo;
        bulletDamage = bullet.GetComponent<BulletDamage>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (InputManager.instance.Fire())
            if (timer > speed)
            {
                if (currentAmmo > 0)
                {
                    switch (type)
                    {
                        case WeaponType.pistol:
                            {
                                bulletDamage.damage = 10;
                                Instantiate(bullet, transform.position, transform.rotation);
                                break;
                            }
                        case WeaponType.shotgun:
                            {
                                bulletDamage.damage = 30;
                                Instantiate(bullet, transform.position, transform.rotation).transform.Rotate(0, Random.Range(-10, 10), 0);
                                Instantiate(bullet, transform.position, transform.rotation).transform.Rotate(0, Random.Range(-10, 10), 0);
                                Instantiate(bullet, transform.position, transform.rotation);
                                Instantiate(bullet, transform.position, transform.rotation).transform.Rotate(0, -Random.Range(-10, 10), 0);
                                Instantiate(bullet, transform.position, transform.rotation).transform.Rotate(0, -Random.Range(-10, 10), 0);
                                break;
                            }
                        case WeaponType.machinegun:
                            {
                                bulletDamage.damage = 5;
                                Instantiate(bullet, transform.position, transform.rotation).transform.Rotate(0, Random.Range(-10,10), 0);
                                break;
                            }

                        default:
                            {
                                Instantiate(bullet, transform.position, transform.rotation);
                                break;
                            }
                    }

                    timer = 0;
                    currentAmmo--;
                }
                else
                {
                    WeaponManager.instance.SetDefaultGun();
                }
            }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    public void TotalyRefillBulletCarger()
    {
        currentAmmo = Ammo;
    }
    public void PartialyRefillBulletCarger(int value)
    {
        currentAmmo += value;

        if (currentAmmo > Ammo)
        {
            TotalyRefillBulletCarger();
        }
    }
}
