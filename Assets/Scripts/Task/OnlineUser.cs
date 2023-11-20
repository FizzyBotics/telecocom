using UnityEngine;
using UnityEngine.UI;

public class OnlineUser : MonoBehaviour
{
    [Range(0, 10)] public int slotsTaken;
    [SerializeField] private Image slotTakenImage;
    void Update()
    {
        slotTakenImage.fillAmount = slotsTaken == 0 ? 0f : Mathf.Clamp01(slotsTaken * 0.1f);
    }
}
