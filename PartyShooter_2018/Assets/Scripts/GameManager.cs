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
        players.Add(playerInstance);
        playerInstance.GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(FadeInObject(playerInstance, FadeInTime));
            
        playerInstance.GetComponent<PlayerManager>().PlayerId = player.GetComponent<PlayerManager>().PlayerId;
        playerInstance.GetComponent<BoxCollider2D>().enabled = true;
    }
    IEnumerator FadeInObject(GameObject fadeObject, float incrementation)
    {

        for (float f = incrementation; f <= 1; f += incrementation)
        {
            Color tmp = fadeObject.GetComponent<SpriteRenderer>().color;
            tmp.a = f;
            fadeObject.GetComponent<SpriteRenderer>().color = tmp;
            yield return new WaitForSeconds(incrementation);
        }           
    }

    private void beginGame()
    {
        Debug.Log("beginGame -> needs to be programmed");
    }
}
