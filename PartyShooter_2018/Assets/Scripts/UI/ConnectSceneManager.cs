using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ConnectSceneManager : MonoBehaviour
{
    public static bool[] PlayersConnected = new bool[4];
    public static bool[] PlayersReady = new bool[4];

    public static string[] ChoosedMaps = new string[4];

    public List<GameObject> PlayersUI;

    public List<GameObject> ChoosableWeaponsPrefabs = new List<GameObject>();
    public List<GameObject> ChoosableItemsPrefabs = new List<GameObject>();
    public List<Sprite> ChoosableMapsForRow1Sprites = new List<Sprite>();
    public List<Sprite> ChoosableMapsForRow2Sprites = new List<Sprite>();

    public List<Color> nameColors = new List<Color>();

    private void Awake()
    {
        //Set List of Button to Panels
        for (int i = 0; i < PlayersUI.Count; i++)
        {
            //Set Name Color
            PlayersUI[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().color = nameColors[i];
            //Weapons
            PlayersUI[i].transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<PosibleEquipmentListManager>().ListedEquipment = ChoosableWeaponsPrefabs;
            //Items
            PlayersUI[i].transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<PosibleEquipmentListManager>().ListedEquipment = ChoosableItemsPrefabs;


            //Maps row 1
            PlayersUI[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<PosibleMapsListManager>().ListedMaps = ChoosableMapsForRow1Sprites;
            if (ChoosableMapsForRow2Sprites.Count > 0)
            {
                //Maps row 2
                PlayersUI[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<PosibleMapsListManager>().ListedMaps = ChoosableMapsForRow2Sprites;
            }
        }
    }
    void Update()
    {
        if (AllConnectedPlayersReady())
        {
            LoadRandomMap();         
        }
    }
    private void LoadRandomMap()
    {
        string finalMap = "";
        do
        {
            finalMap = ChoosedMaps[Random.Range(0, ChoosedMaps.Length - 1)];

        } while (finalMap == "" || finalMap == null || finalMap == string.Empty);

        SceneManager.LoadScene(finalMap);
    }
    private bool AllConnectedPlayersReady()
    {
        int connected = 0;
        int ready = 0;

        for (int i = 0; i < 4; i++)
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
