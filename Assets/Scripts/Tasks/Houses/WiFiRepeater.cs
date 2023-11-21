using UnityEngine;
using UnityEngine.UI;

public class WiFiRepeater : MonoBehaviour
{
    [SerializeField] private GameObject networkRangeGO;
    [SerializeField] private NetworkReceiver networkReceiver;

    private void Awake()
    {
        networkReceiver.OnRangeChange += OnRangeChange;
        OnRangeChange(networkReceiver.IsInRange());
    }

    private void OnRangeChange(bool isInRange)
    {
        networkRangeGO.GetComponent<Image>().enabled = isInRange;
        networkRangeGO.GetComponent<CircleCollider2D>().enabled = isInRange;
    }
}
