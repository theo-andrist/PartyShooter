using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveRifle : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenBullets;
     
    public GameObject Bullet;
    public GameObject BulletSpawn;

    private GameObject GunPivot;

    // Start is called before the first frame update
    void Awake()
    {
        GunPivot = transform.parent.gameObject;
    }

    public void Shoot()
    {
        gameObject.SetActive(true);
        StartCoroutine(ShootValve());
    }
    IEnumerator ShootValve()
    {
        Instantiate(Bullet, BulletSpawn.transform.position, GunPivot.transform.rotation);
        yield return new WaitForSeconds(timeBetweenBullets);
        Instantiate(Bullet, BulletSpawn.transform.position, GunPivot.transform.rotation);
        yield return new WaitForSeconds(timeBetweenBullets);
        Instantiate(Bullet, BulletSpawn.transform.position, GunPivot.transform.rotation);
    }
}
