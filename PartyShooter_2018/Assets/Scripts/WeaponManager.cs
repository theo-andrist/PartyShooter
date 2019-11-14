using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float bulletSpeed;

    public int bulletDamage;

    public int timeBeforeShoot;
    public void Shoot(int ChoosedWeaponId)
    {
        switch (ChoosedWeaponId)
        {
            case 0:
                GetComponent<ValveRifle>().Shoot();
                break;
            default:
                Debug.Log("Name nicht gefunden:" + name);
                break;
        }
    }
}
