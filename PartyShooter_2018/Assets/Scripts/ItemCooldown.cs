using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCooldown : MonoBehaviour
{
    [SerializeField]
    private float cooldown = 0;

    public float Cooldown
    {
        get
        {
            return cooldown;
        }
    }
}
