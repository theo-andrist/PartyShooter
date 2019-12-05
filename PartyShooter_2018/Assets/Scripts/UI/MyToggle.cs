using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyToggle : Toggle
{
    public EventSystem eventSystem;

    private Toggle toggle;
    protected override void Awake()
    {
        base.Awake();
        eventSystem = GetComponent<MyEventSystemProvider>().eventSystem;

        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
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
        ColorBlock cb = toggle.colors;
        if (isOn)
        {
            cb.normalColor = Color.magenta;
            cb.highlightedColor = Color.gray;
        }
        else
        {
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.gray;
        }
        toggle.colors = cb;
    }
    
}
