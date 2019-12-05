using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Color[] Colors;

    private SpriteRenderer gunRenderer;

    public GameObject gunPivotPoint;

    public GameObject WeaponPrefab;

    private GameObject weaponInstance;
    public GameObject WeaponInstance
    {
        get
        {
            return weaponInstance;
        }
    }

    [SerializeField]
    private int playerId;
    public int PlayerId
    {
        get
        {
            return playerId;
        }
        set
        {
            playerId = value;

            gameObject.GetComponent<PlayerMovement>().setInputNames();
            gameObject.GetComponent<PlayerAim>().setInputNames();
        }
    }
    // Start is called before the first frame update
    void Awake()
    {

        //WeaponInstance = Instantiate(JoystickController.choosedWeapons[playerId], gunPivotPoint.transform);
        if (PlayerEquipment.choosedWeapons[playerId] == null)
        {
            weaponInstance = Instantiate(WeaponPrefab, gunPivotPoint.transform);
        }
        else
        {
            weaponInstance = Instantiate(PlayerEquipment.choosedWeapons[playerId], gunPivotPoint.transform);
        }

        gunPivotPoint.transform.rotation = Quaternion.Euler(0, 0, 90);


    }
    private void Start()
    {
        gunRenderer = gameObject.transform.GetChild(2).GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        GetComponent<SpriteRenderer>().color = Colors[playerId];
        GetComponent<SpriteRenderer>().sortingOrder = playerId * 2;
        gunRenderer.sortingOrder = playerId * 2 + 1;
    }
    private void Update()
    {
        
    }
}
