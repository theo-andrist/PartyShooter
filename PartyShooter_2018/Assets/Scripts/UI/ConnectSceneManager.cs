using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ConnectSceneManager : MonoBehaviour
{
    public static bool[] PlayersConnected = new bool[4];

    public static bool[] PlayersReady = new bool[4];

    public GameObject[] JoystickControllersObjects;
    void Update()
    {
        
        if (AllConnectedPlayersReady())
        {
            SceneManager.LoadScene("main");            
        }
    }

    private bool AllConnectedPlayersReady()
    {
        int connected = 0;
        int ready = 0;

        Debug.Log("für mehr spiele, variable ändern");
        for (int i = 0; i < 2; i++)
        {
            if (PlayersConnected[i])
            {
                connected++;
                if (PlayersReady[i])
                {
                    ready++;
                }
            }
        }
        if (ready == connected && ready > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
