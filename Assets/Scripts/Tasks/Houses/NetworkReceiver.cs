using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class NetworkReceiver : MonoBehaviour
{
    [SerializeField] private GameObject ignoredNetworkTransmitterGO;
    private CircleCollider2D circleCollider2D;
    private bool isInRange = false;
    private int? connectedTransmitter = null;
    public delegate void NetworkReceiverRangeEvent(bool isInRange);
    public event NetworkReceiverRangeEvent OnRangeChange;

    private void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.isTrigger = true;
    }

    public bool IsInRange()
    {
        return isInRange;
    }

    private void SetIsInRange(bool value)
    {
        if (value == isInRange) return;
        isInRange = value;
        OnRangeChange?.Invoke(isInRange);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<NetworkTransmitter>() != null && other.gameObject != ignoredNetworkTransmitterGO && connectedTransmitter == null)
        {
            connectedTransmitter = other.GetInstanceID();
            SetIsInRange(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<NetworkTransmitter>() != null && connectedTransmitter == other.GetInstanceID())
        {
            connectedTransmitter = null;
            SetIsInRange(false);
        }
    }
}
