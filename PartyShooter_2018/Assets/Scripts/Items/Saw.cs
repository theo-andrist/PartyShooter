using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private GameObject[] players;

    public GameObject SawPack;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetComponent<ItemManager>().StartDestroyTimer(gameObject));

        players =  GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log("p1: " + players[0].transform.position.x + " p2: " + players[1].transform.position.x);
        GetComponent<Rigidbody2D>().velocity = -transform.up * GetComponent<ItemManager>().throwSpeed;
        for (int i = 0; i < players.Length; i++)
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), players[i].GetComponent<BoxCollider2D>());
        }
        
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * GetComponent<ItemManager>().throwSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(SawPack, gameObject.transform.position, gameObject.transform.rotation);
    }
}
