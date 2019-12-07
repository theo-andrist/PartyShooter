using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PosibleMapsListManager : MonoBehaviour
{
    public GameObject panelManagerObject;
    public GameObject buttonPrefab;
    public List<Sprite> ListedMaps = new List<Sprite>();

    public bool setFirstSelectedToEventSystem;
    public bool setSelectedToEventSystem;

    private bool onEnableIgnored;

    private List<GameObject> buttonInstances = new List<GameObject>();
    private void Start()
    {

        for (int i = 0; i < ListedMaps.Count; i++)
        {
            buttonInstances.Add(Instantiate(buttonPrefab, transform.position, transform.rotation, transform));

            buttonInstances[i].transform.GetChild(0).GetComponentInChildren<Image>().sprite = ListedMaps[i];
            buttonInstances[i].GetComponent<MyToggle>().IsMapButton = true;
            buttonInstances[i].GetComponent<MyToggle>().MapName = ListedMaps[i].name.Replace("Sprite", string.Empty);
            buttonInstances[i].GetComponent<MyToggle>().PlayerId = panelManagerObject.GetComponent<PanelManager>().playerId;
            buttonInstances[i].GetComponent<MyEventSystemProvider>().eventsystem = GameObject.Find("Eventsystem " + (panelManagerObject.GetComponent<PanelManager>().playerId + 1)).GetComponent<MyEventSystem>();
        }

        //Eventsystem first selected
        if (setFirstSelectedToEventSystem)
        {
            GameObject eventSystemObject = GameObject.Find("Eventsystem " + (panelManagerObject.GetComponent<PanelManager>().playerId + 1));
            eventSystemObject.GetComponent<MyEventSystem>().firstSelectedGameObject = buttonInstances[0];
        }

        if (ListedMaps.Count > 0)
        {
            buttonInstances[0].GetComponent<MyToggle>().isOn = true;
        }
        else
        {
            Debug.Log("List empty");
        }

        
        StartCoroutine(setSelectedObject());
    }
    void OnEnable()
    {
        if (onEnableIgnored)
        {
            StartCoroutine(setSelectedObject());
        }
        onEnableIgnored = true;
    }
    IEnumerator setSelectedObject()
    {
        yield return new WaitForEndOfFrame();
        //Eventsystem set selected object
        if (setSelectedToEventSystem)
        {
            GameObject eventSystemObject = GameObject.Find("Eventsystem " + (panelManagerObject.GetComponent<PanelManager>().playerId + 1));
            eventSystemObject.GetComponent<MyEventSystem>().SetSelectedGameObject(buttonInstances[0]);
        }
    }
}
