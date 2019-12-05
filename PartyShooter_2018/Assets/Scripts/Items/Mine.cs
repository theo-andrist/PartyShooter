using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private Rigidbody2D rB;

    private int throwerId;
    public int ThrowerId { get { return throwerId; } set { throwerId = value; } }

    public GameObject ExplosionPrefab;

    /*private float throwSpeed;
    public float ThrowSpeed { get { return throwSpeed; } set { throwSpeed = value; } }*/

    void Start()
    {
        rB = gameObject.GetComponent<Rigidbody2D>();

        rB.velocity = -transform.up * GetComponent<ItemManager>().throwSpeed;

        StartCoroutine(GetComponent<ItemManager>().StartDestroyTimer(gameObject));

    }
    private void Update()
    {

    }
   
    IEnumerator MakeExplode()
    {
        yield return new WaitForSeconds(GetComponent<ItemManager>().DestroyTimer);

        Explode();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerManager>().PlayerId != throwerId)
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeRockhitDamage(GetComponent<ItemManager>().Damage);

                Explode();
            }
    }
    private void Explode()
    {
        //explosion
        Instantiate(ExplosionPrefab, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);

    }
    
}
