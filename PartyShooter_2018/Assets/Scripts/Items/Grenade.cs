using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    private Rigidbody2D rB;

    public float timeBeforeHot;
    private bool hot = false;

    private int throwerId;
    public int ThrowerId { get { return throwerId; } set { throwerId = value; setInputNames(); } }

    public GameObject SpikePack;
    public GameObject ExplosionPrefab;

    private string itemInput;

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
        if (Input.GetAxis(itemInput) > 0.5 && hot)
        {
            Explode();
        }
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
                collision.gameObject.GetComponent<PlayerHealth>().TakeRockhitDamage(GetComponent<ItemManager>().Damage);

                Explode();
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerManager>().PlayerId != throwerId)
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeRockhitDamage(GetComponent<ItemManager>().Damage);

                Explode();
            }
        }
    }
    private void Explode()
    {
        //explosion
        Instantiate(ExplosionPrefab, gameObject.transform.position, transform.rotation);
        Instantiate(SpikePack, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);

    }
    public void setInputNames()
    {
        switch (throwerId)
        {
            case 0:
                itemInput = "P1Item";
                break;
            case 1:
                itemInput = "P2Item";
                break;
            case 2:
                itemInput = "P3Item";
                break;
            case 3:
                itemInput = "P4Item";
                break;
        }
    }
}
