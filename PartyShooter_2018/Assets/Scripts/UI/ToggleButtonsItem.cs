using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ToggleButtonsItem : MonoBehaviour
{
    public GameObject joystickControllerObject;

    private Toggle toggle;

    public GameObject Item;
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }
    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
           /* SingleJoystickManager.choosedItems[joystickControllerObject.GetComponent<SingleJoystickManager>().PlayerId] = Item;

           for (int i = 0; i < 2; i++)
            {
                if (SingleJoystickManager.choosedItems[i] != null)
                {
                    Debug.Log("player " + i + " has item " + SingleJoystickManager.choosedItems[i].transform.name);
                }
            }*/
        }
    }
}
