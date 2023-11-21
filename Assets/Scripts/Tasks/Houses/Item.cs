using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Item : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [HideInInspector]
    public GameObject hoveredOverObject;

    public void OnBeginDrag(PointerEventData eventData)
    {
        eventData.pointerDrag = gameObject;
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (hoveredOverObject != null)
        {
            transform.position = hoveredOverObject.transform.position;
        }
        else
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        if (hoveredOverObject != null && hoveredOverObject.GetComponent<ItemDestroyer>() != null)
        {
            Destroy(gameObject);
        }
    }
}