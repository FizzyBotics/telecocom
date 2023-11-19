using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpawner : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField] private GameObject itemPrefab;

    public void OnBeginDrag(PointerEventData eventData)
    {
        eventData.pointerDrag = Instantiate(itemPrefab, transform);
        eventData.pointerDrag.GetComponent<Item>().OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
