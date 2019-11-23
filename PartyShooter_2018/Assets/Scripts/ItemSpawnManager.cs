using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public bool gunReversed;

    public GameObject WeaponPrefab;

    public Transform itemSpawnPoint;

    public void Awake()
    {
        if (JoystickController.choosedItems[GetComponent<PlayerManager>().PlayerId] != null)
        {
            WeaponPrefab = JoystickController.choosedItems[GetComponent<PlayerManager>().PlayerId];
        }
    }

    public void throwItem()
    {
        GameObject itemInstance = Instantiate(WeaponPrefab, itemSpawnPoint.position, itemSpawnPoint.transform.rotation);

        switch (WeaponPrefab.transform.name)
        {
            case "Grenade":
                itemInstance.GetComponent<Grenade>().throwerId = GetComponent<PlayerManager>().PlayerId;
                break;
            default:
                Debug.Log("Weponprefab-name uncorrect in script");
                break;
        }
        
    }
}
