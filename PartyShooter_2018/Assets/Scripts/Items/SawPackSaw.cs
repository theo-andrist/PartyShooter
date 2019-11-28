using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPackSaw : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeRockhitDamage(Damage);
            Destroy(gameObject);
        }
    }
}
