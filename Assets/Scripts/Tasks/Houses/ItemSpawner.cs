using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpawner : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField] private GameObject itemPrefab;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        eventData.pointerDrag = Instantiate(itemPrefab, transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
