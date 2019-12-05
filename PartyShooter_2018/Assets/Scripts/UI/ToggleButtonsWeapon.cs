using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ToggleButtonsWeapon: MonoBehaviour
{
    public GameObject joystickControllerObject;

    private Toggle toggle;

    public GameObject weapon;
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }
    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
           // SingleJoystickManager.choosedWeapons[joystickControllerObject.GetComponent<SingleJoystickManager>().PlayerId] = weapon;

           /* for (int i = 0; i < JoystickController.choosedItems.Length; i++)
            {
                if (JoystickController.choosedItems[i] != null)
                {
                    Debug.Log("player " + i + " has item " + JoystickController.choosedItems[i].transform.name);
                }
            }*/
        }
    }
}
