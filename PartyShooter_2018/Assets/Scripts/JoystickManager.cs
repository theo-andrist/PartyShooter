using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    public static List<int> idOfPlayerConnected = new List<int>();

    [SerializeField]
    private GameObject[] JoystickControllers;

    void Update()
    {
        
        if (AllConnectedPlayersReady())
        {
            for (int i = 0; i < 4; i++)
            {
                if (JoystickControllers[i].GetComponent<JoystickController>().Connected)
                {
                    idOfPlayerConnected.Add(JoystickControllers[i].GetComponent<JoystickController>().PlayerId);
                }
            }

            SceneManager.LoadScene("main");            
        }
    }

    private bool AllConnectedPlayersReady()
    {
        bool allPlayersReady = false;
        int _i = 0;

        if (JoystickControllers[0].GetComponent<JoystickController>().Connected || JoystickControllers[1].GetComponent<JoystickController>().Connected || JoystickControllers[2].GetComponent<JoystickController>().Connected || JoystickControllers[3].GetComponent<JoystickController>().Connected)
        {
            for (int i = 0; i < 4; i++)
            {
                if (JoystickControllers[i].GetComponent<JoystickController>().Connected == JoystickControllers[i].GetComponent<JoystickController>().Ready)
                {
                    _i++;
                }
            }
        }
        if (_i == 4)
        {
            allPlayersReady = true;
        }

        return allPlayersReady;
    }
}
