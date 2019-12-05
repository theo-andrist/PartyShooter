using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletValveRifle : MonoBehaviour
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

    /*public Sprite[] sprites;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }*/
    private void Start()
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

