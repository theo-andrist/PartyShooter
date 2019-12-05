using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public string WeaponName;

    public float bulletSpeed;

    public int bulletDamage;

    public int shootRate;
    public void Shoot()
    {
        switch (WeaponName)
        {
            case "Valve-Rifle":
                GetComponent<ValveRifle>().Shoot();
                break;
            default:
                Debug.Log("Name nicht gefunden:" + name);
                break;
        }
    }
}
