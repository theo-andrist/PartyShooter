using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyToggle : Toggle
{
    public EventSystem eventSystem;

    public bool IsMapButton;
    public GameObject EquipmentPrefab;
    public string MapName;
    public int PlayerId;
    

    private Toggle toggle;
    protected override void Awake()
    {
        base.Awake();
        eventSystem = GetComponent<MyEventSystemProvider>().eventsystem;

        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);

        if (GetComponentInParent<ToggleGroup>() != null)
        {
            toggle.group = GetComponentInParent<ToggleGroup>();
        }
        
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        // Selection tracking
        if (IsInteractable() && navigation.mode != Navigation.Mode.None)
            eventSystem.SetSelectedGameObject(gameObject, eventData);

        base.OnPointerDown(eventData);
    }

    public override void Select()
    {
        if (eventSystem.alreadySelecting)
            return;

        eventSystem.SetSelectedGameObject(gameObject);
    }
    private void OnToggleValueChanged(bool isOn)
    {
        //SetColor
        ColorBlock cb = toggle.colors;
        if (isOn)
        {
            cb.normalColor = Color.blue;
            cb.highlightedColor = Color.cyan;
        }
        else
        {
            cb.normalColor = Color.gray;
            cb.highlightedColor = Color.white;
        }
        toggle.colors = cb;

        if (IsMapButton)
        {
            //SetChoosedMap
            if(isOn)
            {
                ConnectSceneManager.ChoosedMaps[PlayerId] = MapName;
            }
        }
        else
        {
            //SetChoosedEquipment
            if (isOn)
            {
                switch (EquipmentPrefab.transform.tag)
                {
                    case "Item":
                        PlayerEquipment.choosedItems[PlayerId] = EquipmentPrefab;
                        break;
                    case "Weapon":
                        PlayerEquipment.choosedWeapons[PlayerId] = EquipmentPrefab;
                        break;
                }

            }
        }
        
        
    }
}
