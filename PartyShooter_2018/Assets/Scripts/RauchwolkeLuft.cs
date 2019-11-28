using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RauchwolkeLuft : MonoBehaviour
{
    public float Speed;
    public float Decrementation;
    void Start()
    {
        StartCoroutine(fadeOut());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += -transform.up * Time.deltaTime * Speed;
    }
    IEnumerator fadeOut()
    {
        for (float f = 1f; f >= -0.05; f -= Decrementation)
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = f;
            GetComponent<SpriteRenderer>().color = tmp;
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }
}
