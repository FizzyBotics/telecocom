using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler
{
    public int buttonIndex;
    public delegate void ButtonAction(int buttonIndex);
    public ButtonAction OnButtonHovered;
    public ButtonAction OnButtonSelected;

    public void AnimateHovered()
    {
        Debug.Log("Button " + buttonIndex + " hovered");
    }

    public void AnimateUnhovered()
    {
        Debug.Log("Button " + buttonIndex + " unhovered");
    }

    public void AnimateSelected()
    {
        Debug.Log("Button " + buttonIndex + " selected");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnButtonHovered(buttonIndex);
    }

    public void OnSelection()
    {
        OnButtonSelected(buttonIndex);
    }
}
