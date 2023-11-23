using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(NetworkReceiver))]
public class NetworkTester : MonoBehaviour
{
    [HideInInspector]
    public NetworkReceiver networkReceiver;

    private void Awake()
    {
        networkReceiver = GetComponent<NetworkReceiver>();
        networkReceiver.OnRangeChange += OnRangeChange;
    }

    private void OnRangeChange(bool isInRange)
    {
        GetComponent<Image>().color = isInRange ? Color.green : Color.red;
    }
}
