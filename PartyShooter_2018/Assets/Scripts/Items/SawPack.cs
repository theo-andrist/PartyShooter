using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPack : MonoBehaviour
{
    public float rotationSpeed;

    public float destroyTimer;
    private void Start()
    {
        StartCoroutine(startDestroyTimer());
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotationSpeed));
    }
    IEnumerator startDestroyTimer()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }
}
