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

        if (JoystickManager.idOfPlayerConnected.Count < 1)
        {
            JoystickManager.idOfPlayerConnected.Add(0);
            JoystickManager.idOfPlayerConnected.Add(1);
            //JoystickManager.idOfPlayerConnected.Add(2);
            //JoystickManager.idOfPlayerConnected.Add(3);
        }

        for (int i = 0; i < JoystickManager.idOfPlayerConnected.Count; i++)
        {
            GameObject playerInstance = Instantiate(PlayerPrefab, SpawnPoints[i].transform.position, PlayerPrefab.transform.rotation);
            playerInstance.GetComponent<PlayerManager>().PlayerId = JoystickManager.idOfPlayerConnected[i];
            players.Add(playerInstance);
        }

    }
    void Update()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].transform.position.y < BottomDeadLine)
            {
                players[i].GetComponent<PlayerHealth>().TakeDamage(1000f);
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

    private void beginGame()
    {
        Debug.Log("beginGame -> needs to be programmed");
    }
}
