using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePack : MonoBehaviour
{
    public float destroyTimer;
    void Awake()
    {
        StartCoroutine(startDestroyTimer());
    }
    IEnumerator startDestroyTimer()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }
}
