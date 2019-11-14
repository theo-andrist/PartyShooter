using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    
    public int Damage;
    
    public int ThrowSpeed;

    public float TimeBeforeExploding;

    private Rigidbody2D rB;

    public float timeBeforeHot;
    private bool hot = false;

    private int playerNbOfThrower;
    public int PlayerNBOfThrower { get { return playerNbOfThrower; } set { playerNbOfThrower = value; } }

    private bool gunReversed;
    public bool GunReversed {

        get
        {
            return gunReversed;
        }

        set
        {
            gunReversed = value;

            if (gunReversed)
            {
                rB.velocity = -transform.right * ThrowSpeed;
            }
            else
            {
                rB.velocity = transform.right * ThrowSpeed;
            }
        }

    }

    void Awake()
    {
        rB = gameObject.GetComponent<Rigidbody2D>();
        
        StartCoroutine(MakeHot());
        StartCoroutine(MakeExplode());
    }

    IEnumerator MakeHot()
    {
        yield return new WaitForSeconds(timeBeforeHot);

        hot = true;
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
    }
    IEnumerator MakeExplode()
    {
        yield return new WaitForSeconds(TimeBeforeExploding);

        Explode();        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hot)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);

                Explode();
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerManager>().PlayerId != playerNbOfThrower)
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);

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
