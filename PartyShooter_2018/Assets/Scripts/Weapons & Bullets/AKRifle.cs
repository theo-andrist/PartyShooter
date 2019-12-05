using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKRifle : MonoBehaviour
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

        GameObject BulletInstance = Instantiate(Bullet, BulletSpawn.transform.position, GunPivot.transform.rotation);
        BulletInstance.GetComponent<BulletValveRifle>().Weapon = gameObject;
    }
}
