using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] SpawnPoints;

    public GameObject PlayerPrefab;

    public float FadeInTime;

    public int BottomDeadLine;

    [SerializeField]
    private List<GameObject> players;
    public List<GameObject> Players
    {
        get
        {
            return players;
        }
        set
        {
            players = value; 
        }
    }
    private void Start()
    {
        List<int> IdOfPlayersConnected = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            if (ConnectSceneManager.PlayersConnected[i] == true)
            {
                IdOfPlayersConnected.Add(i);
            }
        }

        if (IdOfPlayersConnected.Count < 1)
        {
            IdOfPlayersConnected.Add(0);
            IdOfPlayersConnected.Add(1);
            //JoystickManager.idOfPlayerConnected.Add(2);
            //JoystickManager.idOfPlayerConnected.Add(3);
        }
        for (int i = 0; i < IdOfPlayersConnected.Count; i++)
        {
            Debug.Log("Player: " + i + "Weapon: " + PlayerEquipment.choosedWeapons + "Item: " + PlayerEquipment.choosedItems);
        }
        
        for (int i = 0; i < IdOfPlayersConnected.Count; i++)
        {
            GameObject playerInstance = Instantiate(PlayerPrefab, SpawnPoints[i].transform.position, PlayerPrefab.transform.rotation);
            playerInstance.GetComponent<PlayerManager>().PlayerId = IdOfPlayersConnected[i];
            players.Add(playerInstance);
        }

        beginGame();

    }
    void Update()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].transform.position.y < BottomDeadLine)
            {
                players[i].GetComponent<PlayerHealth>().TakeRockhitDamage(1000f);
                players.Remove(players[i]);
            }
        }
    }
    public IEnumerator RespawnPlayer(GameObject player, float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);

        int rnd = Random.Range(0, SpawnPoints.Length);

        GameObject playerInstance = Instantiate(PlayerPrefab, SpawnPoints[rnd].transform.position, PlayerPrefab.transform.rotation);
        playerInstance.GetComponent<PlayerHealth>().indestructible = true;
        players.Add(playerInstance);
        playerInstance.GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(FadeInPlayer(playerInstance, FadeInTime));
            
        playerInstance.GetComponent<PlayerManager>().PlayerId = player.GetComponent<PlayerManager>().PlayerId;
        playerInstance.GetComponent<BoxCollider2D>().enabled = true;
    }
    IEnumerator FadeInPlayer(GameObject player, float incrementation)
    {

        for (float f = incrementation; f <= 1; f += incrementation)
        {
            Color tmp = player.GetComponent<SpriteRenderer>().color;
            tmp.a = f;
            player.GetComponent<SpriteRenderer>().color = tmp;
            yield return new WaitForSeconds(incrementation);
        }
        player.GetComponent<PlayerHealth>().indestructible = false;
    }

    IEnumerator beginGame()
    {
        //Gameobject countdownPanel = 
        yield return new WaitForSeconds(1);
        Debug.Log("beginGame -> needs to be programmed");
    }
}
