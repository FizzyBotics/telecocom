using UnityEngine;
using UnityEngine.UI;
public class Star : MonoBehaviour
{
    [SerializeField] private GameObject windows;
    [SerializeField] private Image star;
    private RectTransform rectTransform;

    public float duration = 3f;

    void Start()
    {
        rectTransform = windows.GetComponent<RectTransform>();
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0f, -5.2f * GetScreenSizeInPixels(), 0f);
        LeanTween.move(gameObject, endPos, duration)
            .setEase(LeanTweenType.easeOutElastic)
            .setOnComplete(OnMovementComplete);
    }


    public float GetTheCurrentHeightWindows(float x)
    {
        float valeurInitiale = rectTransform.rect.height;
        float nouvelleValeur = x / 1080f * valeurInitiale;
        return nouvelleValeur;
    }


    public float GetScreenSizeInPixels()
    {
        return GetTheCurrentHeightWindows(Screen.height);
    }

    void OnMovementComplete()
    {

    }

    public void SetOpacity(float a)
    {
        Color currentColor = star.color;
        currentColor.a = a;
        star.color = currentColor;
    }
}


