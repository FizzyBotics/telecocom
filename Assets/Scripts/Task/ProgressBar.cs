using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [Range(0f, 100f)] public float value;
    [SerializeField] private Image leftCorner, middle, rightCorner;

    void Update()
    {
        if (value <= 0.0f)
        {
            leftCorner.fillAmount = 0;
            middle.fillAmount = 0;
            rightCorner.fillAmount = 0;
        }
        else if (value >= 0 && value <= 5)
        {
            leftCorner.fillAmount = value / 5f;
            middle.fillAmount = 0;
            rightCorner.fillAmount = 0;
        }
        else if (value > 5 && value <= 95)
        {
            leftCorner.fillAmount = 1;
            middle.fillAmount = (value - 5f) / 90f;
            rightCorner.fillAmount = 0;
        }
        else if (value > 95 && value <= 100)
        {
            leftCorner.fillAmount = 1;
            middle.fillAmount = 1;
            rightCorner.fillAmount = (value - 95f) / 5f;
        }
    }
}


