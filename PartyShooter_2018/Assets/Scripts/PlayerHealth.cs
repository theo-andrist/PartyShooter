using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100;

    public float RespawnTime;

    public bool PlayerAlive = true;

    private GameObject GameManagerObject;
    private GameManager gameManager;

    public Slider healthSlider;

    private void Start()
    {
        GameManagerObject = GameObject.Find("GameManager");
        gameManager = GameManagerObject.GetComponent<GameManager>();
    }

    private void Update()
    {
        healthSlider.value = Health;

        if (Health <= 0 && PlayerAlive)
        {
            PlayerAlive = false;
            StartCoroutine(gameManager.RespawnPlayer(gameObject, RespawnTime));

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
