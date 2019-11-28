using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RauchwolkeBoden : MonoBehaviour
{
    public float Decrementation;
    public float Speed;
    public Vector3 Direction;
    void Awake()
    {
        StartCoroutine(fadeOut());
    }
    void FixedUpdate()
    {
        transform.position += Direction * Time.deltaTime * Speed;
    }
    IEnumerator fadeOut()
    {
        for (float f = 0.75f; f >= -0.05; f -= Decrementation)
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = f;
            GetComponent<SpriteRenderer>().color = tmp;
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }
}
