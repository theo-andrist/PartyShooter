using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBall : MonoBehaviour
{
    private GameObject weapon;
    public GameObject Weapon
    {
        set
        {
            weapon = value;
        }
    }
    private float speed;

    private float damage;

    void Start()
    {
        speed = weapon.GetComponent<WeaponManager>().bulletSpeed;
        damage = weapon.GetComponent<WeaponManager>().bulletDamage;
    }
    private void FixedUpdate()
    {
        transform.position += -transform.up * speed * Time.deltaTime;

        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeRockhitDamage(damage);
        }

        Destroy(gameObject);
    }
}
