using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public int playerId;

    public GameObject ConnectPanel;
    public GameObject EquipmentPanel;
    public GameObject MapPanel;

    private int actualPanelLayer = 0;

    

    void Update()
    {
        if (Input.GetButtonDown("P" + (playerId + 1) + "Ready") && actualPanelLayer < 3)
        {
            actualPanelLayer++;
            setVisiblePanel(actualPanelLayer);
        }
        if (Input.GetButtonDown("P" + (playerId + 1) + "Back") && actualPanelLayer > 1)
        {
            actualPanelLayer--;
            setVisiblePanel(actualPanelLayer);
        }

        
        
    }
    void setVisiblePanel(int _nbOfPanelDisabled)
    {
        switch (_nbOfPanelDisabled)
        {
            case 1:
                ConnectSceneManager.PlayersConnected[playerId] = true;

                if (ConnectPanel.activeInHierarchy)
                {
                    ConnectPanel.SetActive(false);
                }
                EquipmentPanel.SetActive(true);

                if (MapPanel.activeInHierarchy)
                {
                    MapPanel.SetActive(false);
                }                
                break;

            case 2:
                if (ConnectSceneManager.PlayersReady[playerId])
                {
                    ConnectSceneManager.PlayersReady[playerId] = false;
                }

                if (EquipmentPanel.activeInHierarchy)
                {
                    EquipmentPanel.SetActive(false);
                }

                MapPanel.SetActive(true);

                
                break;

            case 3:
                ConnectSceneManager.PlayersReady[playerId] = true;
                break;
        }

    }
}
