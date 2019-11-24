using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePackSpike : MonoBehaviour
{
    public float Speed;

    public int Damage;
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * Speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
    
}
