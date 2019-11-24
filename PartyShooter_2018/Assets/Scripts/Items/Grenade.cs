using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    private Rigidbody2D rB;

    public float timeBeforeHot;
    private bool hot = false;

    private int throwerId;
    public int ThrowerId { get { return throwerId; } set { throwerId = value; } }

    public GameObject SpikePack;

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
        yield return new WaitForSeconds(GetComponent<ItemManager>().DestroyTimer);

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
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerManager>().PlayerId != throwerId)
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(GetComponent<ItemManager>().Damage);

                Explode();
            }
        }
    }
    private void Explode()
    {
        //explosion
        Instantiate(SpikePack, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
