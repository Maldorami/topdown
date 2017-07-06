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
    
    public Pool BulletPoolManager;

    public float speed = 1;


    public float currentAmmo;
    public float Ammo;

    float timer = 0;

    AudioSource sx;
    bool machinegun = false;

    void Start()
    {
        currentAmmo = Ammo;
        sx = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (InputManager.instance.Fire())
        {
            if (timer > speed)
            {
                if (currentAmmo > 0)
                {
                    switch (type)
                    {
                        case WeaponType.pistol:
                            {
                                GameObject bullet = BulletPoolManager.Spawn().gameObject;
                                bullet.transform.position = transform.position;
                                bullet.transform.rotation = transform.rotation;
                                bullet.GetComponent<BulletDamage>().damage = 10;

                                PlaySX();

                                break;
                            }
                        case WeaponType.shotgun:
                            {
                                GameObject bullet1 = BulletPoolManager.Spawn().gameObject;
                                bullet1.transform.position = transform.position;
                                bullet1.transform.rotation = transform.rotation;
                                bullet1.transform.Rotate(0, Random.Range(-10, 10), 0);

                                GameObject bullet2 = BulletPoolManager.Spawn().gameObject;
                                bullet2.transform.position = transform.position;
                                bullet2.transform.rotation = transform.rotation;
                                bullet2.transform.Rotate(0, Random.Range(-10, 10), 0);

                                GameObject bullet3 = BulletPoolManager.Spawn().gameObject;
                                bullet3.transform.position = transform.position;
                                bullet3.transform.rotation = transform.rotation;
                                bullet3.transform.Rotate(0, -Random.Range(-10, 10), 0);

                                GameObject bullet4 = BulletPoolManager.Spawn().gameObject;
                                bullet4.transform.position = transform.position;
                                bullet4.transform.rotation = transform.rotation;
                                bullet4.transform.Rotate(0, -Random.Range(-10, 10), 0);

                                GameObject bullet5 = BulletPoolManager.Spawn().gameObject;
                                bullet5.transform.position = transform.position;
                                bullet5.transform.rotation = transform.rotation;

                                bullet1.GetComponent<BulletDamage>().damage = 30;
                                bullet2.GetComponent<BulletDamage>().damage = 30;
                                bullet3.GetComponent<BulletDamage>().damage = 30;
                                bullet4.GetComponent<BulletDamage>().damage = 30;
                                bullet5.GetComponent<BulletDamage>().damage = 30;

                                sx.Play();

                                break;
                            }
                        case WeaponType.machinegun:
                            {
                                GameObject bullet = BulletPoolManager.Spawn().gameObject;
                                bullet.transform.position = transform.position;
                                bullet.transform.rotation = transform.rotation;
                                bullet.transform.Rotate(0, Random.Range(-10, 10), 0);

                                bullet.GetComponent<BulletDamage>().damage = 5;
                                bullet.GetComponent<DestroyAt>().timer = 1;

                                if (!sx.isPlaying)
                                {
                                    sx.Play();
                                }

                                break;
                            }

                        default:
                            {
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
        else
        {
            if(type == WeaponType.machinegun)
            sx.Stop();
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

    void PlaySX()
    {
        if (sx.isPlaying)
        {
            sx.Stop();
        }

        sx.Play();
    }
}
