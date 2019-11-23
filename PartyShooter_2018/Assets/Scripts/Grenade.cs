using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    private Rigidbody2D rB;

    public float timeBeforeHot;
    private bool hot = false;

    private int playerNbOfThrower;
    public int throwerId { get { return playerNbOfThrower; } set { playerNbOfThrower = value; } }

    /*private float throwSpeed;
    public float ThrowSpeed { get { return throwSpeed; } set { throwSpeed = value; } }*/

    void Start()
    {
        rB = gameObject.GetComponent<Rigidbody2D>();

        
        rB.velocity = -transform.up * GetComponent<ItemManager>().throwSpeed;
        

        StartCoroutine(MakeHot());
        StartCoroutine(MakeExplode());
    }
    private void Update()
    {
        
    }
    IEnumerator MakeHot()
    {
        yield return new WaitForSeconds(timeBeforeHot);

        hot = true;
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
    }
    IEnumerator MakeExplode()
    {
        yield return new WaitForSeconds(GetComponent<ItemManager>().timeBeforeDestroying);

        Explode();        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hot)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(GetComponent<ItemManager>().Damage);

                Explode();
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerManager>().PlayerId != playerNbOfThrower)
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(GetComponent<ItemManager>().Damage);

                Explode();
            }
        }
    }
    private void Explode()
    {
        //explosion

        Destroy(gameObject);

    }
}
