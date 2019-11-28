using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100;

    public float RespawnTime;

    public bool PlayerAlive = true;

    public GameObject indestructibleField;
    public bool indestructible;

    private GameObject GameManagerObject;
    private GameManager gameManager;

    public Slider healthSlider;

    public GameObject HitMarkerPrefab;

    private void Start()
    {
        GameManagerObject = GameObject.Find("GameManager");
        gameManager = GameManagerObject.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (PlayerAlive)
        {
            if (indestructible)
            {
                indestructibleField.SetActive(true);
            }
            else
            {
                indestructibleField.SetActive(false);
            }

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
    }

    public void TakeRockhitDamage(float damage)
    {
        if (!indestructible)
        {
            Health -= damage;
            Instantiate(HitMarkerPrefab, transform.position, HitMarkerPrefab.transform.rotation);
        }
    }
}
