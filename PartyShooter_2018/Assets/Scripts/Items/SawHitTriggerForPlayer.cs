﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawHitTriggerForPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeRockhitDamage(transform.parent.GetComponent<ItemManager>().Damage);
        }
    }
}
