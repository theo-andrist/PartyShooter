using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController: MonoBehaviour
{
    [SerializeField]
    private int playerId;
    public int PlayerId
    {
        get { return playerId; }
        set { playerId = value; }
    }

    private bool connected;
    public bool Connected
    {
        get { return connected; }
        set { connected = value; }
    }

    private bool ready;
    public bool Ready
    {
        get { return ready; }
        set { ready = value; }
    }
    public static GameObject[] choosedWeapons = new GameObject[4];

    public static GameObject[] choosedItems = new GameObject[4];

    void Update()
    {
        switch (playerId)
        {
            case 0:
                if (Input.GetButtonDown("P1Submit") && !connected)
                {
                    connected = true;
                    GameObject.Find("Canvas/P1/PressAToConnect").SetActive(false);
                    Debug.Log("P1Connected");
                }
                else if (Input.GetButtonDown("P1Submit"))
                {
                    ready = true;
                    Debug.Log("P1Ready");
                }
                break;

            case 1:
                if (Input.GetButtonDown("P2Submit") && !connected)
                {
                    connected = true;
                    GameObject.Find("Canvas/P2/PressAToConnect").SetActive(false);
                    Debug.Log("P2Connected");
                }
                else if (Input.GetButtonDown("P2Submit"))
                {
                    ready = true;
                    Debug.Log("P2Ready");
                }
                break;

            case 2:
                if (Input.GetButtonDown("P3Submit") && !connected)
                {
                    connected = true;
                    GameObject.Find("Canvas/P3/PressAToConnect").SetActive(false);
                    Debug.Log("P3Connected");
                }
                else if (Input.GetButtonDown("P3Submit"))
                {
                    ready = true;
                    Debug.Log("P3Ready");
                }
                break;

            case 3:
                if (Input.GetButtonDown("P4Submit") && !connected)
                {
                    connected = true;
                    GameObject.Find("Canvas/P4/PressAToConnect").SetActive(false);
                    Debug.Log("P4Connected");
                }
                else if (Input.GetButtonDown("P4Submit"))
                {
                    ready = true;
                    Debug.Log("P4Ready");
                }
                break;
        }
    }
}
