using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public bool gunReversed;

    public GameObject ItemPrefab;

    public Transform itemSpawnPoint;

    public void throwItem()
    {
        if (PlayerEquipment.choosedItems[GetComponent<PlayerManager>().PlayerId] != null)
        {
            ItemPrefab = PlayerEquipment.choosedItems[GetComponent<PlayerManager>().PlayerId];
            Debug.Log("!");
        }

        GameObject itemInstance;

        //für SpawnPositionsVerschiebung des items
        switch (ItemPrefab.transform.name)
        {
            case "Saw":
                itemInstance = Instantiate(ItemPrefab, itemSpawnPoint.position + -itemSpawnPoint.transform.up * ItemPrefab.transform.localScale.x / 2, itemSpawnPoint.transform.rotation);
                break;
            default:
                itemInstance = Instantiate(ItemPrefab, itemSpawnPoint.position, itemSpawnPoint.transform.rotation);
                break;
        }

        //Um Eigenschaften des Instanzierten Items zu setzen
        switch (ItemPrefab.transform.name)
        {
            case "Grenade":
                itemInstance.GetComponent<Grenade>().ThrowerId = GetComponent<PlayerManager>().PlayerId;
                break;
            case "Saw":
                
                break;
            default:
                Debug.Log("Weponprefab-name uncorrect in script or not set");
                break;
        }
        
    }
}
