﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAim : MonoBehaviour
{
    public GameObject GunPivot;

    public Image shootBulletTimer;
    private float bulletCountUp;
    private bool allowedToShoot = false;

    private GameObject WeaponManager;

    public GameObject Item;
    public Image shootItemTimer;
    private float itemCountUp;
    private bool allowedToShootItem = false;

    private string aimHorizontal;
    private string aimVertical;
    private string fireInput;
    private string itemInput;

    private bool gunReversed = false;

    private void Start()
    {
        WeaponManager = GameObject.Find("WeaponManager");
        setInputNames();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerHealth>().PlayerAlive)
        {
            if (gameObject.GetComponent<PlayerHealth>().PlayerAlive)
            {
                if (Input.GetAxis(aimHorizontal) != 0 && Input.GetAxis(aimVertical) != 0)
                {
                    GunPivot.transform.eulerAngles = new Vector3(GunPivot.transform.eulerAngles.x, GunPivot.transform.eulerAngles.y, Mathf.Atan2(Input.GetAxis(aimHorizontal), Input.GetAxis(aimVertical)) * Mathf.Rad2Deg);

                    if (GunPivot.transform.rotation.z < 0 || GunPivot.transform.rotation.z > 180 && !gunReversed)
                    {
                        GunPivot.transform.localScale = new Vector3(-1f, 1f, 1);
                        gunReversed = true;
                    }
                    else
                    {
                        GunPivot.transform.localScale = new Vector3(1f, 1f, 1);
                        gunReversed = false;
                    }
                }
                if (bulletCountUp < GetComponent<PlayerManager>().WeaponInstance.GetComponent<WeaponManager>().timeBeforeShoot)
                {
                    bulletCountUp += Time.deltaTime;

                    shootBulletTimer.GetComponent<Image>().fillAmount = bulletCountUp / GetComponent<PlayerManager>().WeaponInstance.GetComponent<WeaponManager>().timeBeforeShoot;
                }
                else
                {
                    allowedToShoot = true;
                }

                if (Input.GetAxis(fireInput) > 0)
                {
                    if (allowedToShoot)
                    {
                        try
                        {
                            GetComponent<PlayerManager>().WeaponInstance.GetComponent<WeaponManager>().Shoot(GetComponent<PlayerManager>().PlayerId);
                        }
                        catch (System.Exception e)
                        {
                            Debug.Log("neu erstellte waffe hat script Weaponshoot?" + e);
                        }
                        

                        bulletCountUp = 0;
                        allowedToShoot = false;
                    }
                }

               /* if (itemCountUp < Item.GetComponent<Item>().Cooldown)
                {
                    itemCountUp += Time.deltaTime;

                    shootItemTimer.GetComponent<Image>().fillAmount = itemCountUp / Item.GetComponent<Item>().Cooldown;
                }
                else
                {
                    allowedToShootItem = true;
                }*/
                if (Input.GetAxis(itemInput) > 0.5 && allowedToShootItem)
                {
                    /*GameObject itemInstance = Instantiate(Item, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
                    itemInstance.GetComponent<Grenade>().GunReversed = gunReversed;
                    itemInstance.GetComponent<Grenade>().PlayerNBOfThrower = GetComponent<PlayerManager>().PlayerId;*/

                    itemCountUp = 0;
                    allowedToShootItem = false;
                }
            }
        }
    }

    public void setInputNames()
    {
        switch (gameObject.GetComponent<PlayerManager>().PlayerId)
        {
            case 0:
                aimHorizontal = "P1AimHorizontal";
                aimVertical = "P1AimVertical";
                fireInput = "P1Fire";
                itemInput = "P1Item";
                break;
            case 1:
                aimHorizontal = "P2AimHorizontal";
                aimVertical = "P2AimVertical";
                fireInput = "P2Fire";
                itemInput = "P2Item";
                break;
            case 2:
                aimHorizontal = "P3AimHorizontal";
                aimVertical = "P3AimVertical";
                fireInput = "P3Fire";
                itemInput = "P3Item";
                break;
            case 3:
                aimHorizontal = "P4AimHorizontal";
                aimVertical = "P4AimVertical";
                fireInput = "P4Fire";
                itemInput = "P4Item";
                break;
        }
    }
}