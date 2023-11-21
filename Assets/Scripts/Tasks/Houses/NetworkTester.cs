using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(NetworkReceiver))]
public class NetworkTester : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<NetworkReceiver>().OnRangeChange += OnRangeChange;
    }

    private void OnRangeChange(bool isInRange)
    {
        GetComponent<Image>().color = isInRange ? Color.green : Color.red;
    }
}
