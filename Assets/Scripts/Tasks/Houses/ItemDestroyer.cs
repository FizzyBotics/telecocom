using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDestroyer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Item>() != null)
        {
            eventData.pointerDrag.GetComponent<Item>().hoveredOverObject = gameObject;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Item>() != null)
        {
            if (eventData.pointerDrag.GetComponent<Item>().hoveredOverObject == gameObject)
            {
                eventData.pointerDrag.GetComponent<Item>().hoveredOverObject = null;
            }
        }
    }
}
