using UnityEngine;
using UnityEngine.UI;

public enum StatusType { ON, OFF };

public class Status : MonoBehaviour
{
    public StatusType status;
    [SerializeField] private Image on;
    void Update() => on.enabled = status == StatusType.ON;
    public void SwitchMode() => status = (status == StatusType.ON) ? StatusType.OFF : StatusType.ON;

}
