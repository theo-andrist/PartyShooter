using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnumPistol : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSpawn;

    private GameObject GunPivot;

    void Awake()
    {
        GunPivot = transform.parent.gameObject;
    }

    public void Shoot()
    {
        gameObject.SetActive(true);
        Instantiate(Bullet, BulletSpawn.transform.position, GunPivot.transform.rotation);
    }
}
