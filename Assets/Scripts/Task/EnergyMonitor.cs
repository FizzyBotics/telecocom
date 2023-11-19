using UnityEngine;
using UnityEngine.UI;

public class EnergyMonitor : MonoBehaviour
{

    [Range(0, 1)] public float value;
    [SerializeField] private Image yellowLightning;
    [SerializeField] private Slider circleProgressBar;
    void Update()
    {
        yellowLightning.fillAmount = value;
        circleProgressBar.value = value;
    }
}
