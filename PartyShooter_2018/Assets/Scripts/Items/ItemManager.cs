using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int Damage;

    public float DestroyTimer;

    public float throwSpeed;

    public float throwRate;

    public IEnumerator StartDestroyTimer(GameObject toDestroyObject)
    {
        yield return new WaitForSeconds(DestroyTimer);

        Destroy(toDestroyObject);
    }

}
