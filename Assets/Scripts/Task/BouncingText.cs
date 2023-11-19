using UnityEngine;

public class BouncingText : MonoBehaviour
{
    [SerializeField] private GameObject windows;
    private RectTransform rectTransform;

    public float duration = 3f;

    void Start()
    {
        rectTransform = windows.GetComponent<RectTransform>();
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0f, -35 * GetScreenSizeInPixels(), 0f);
        LeanTween.move(gameObject, endPos, duration)
            .setEase(LeanTweenType.easeOutElastic)
            .setOnComplete(OnMovementComplete);
    }


    public float GetTheCurrentHeightWindows(float x)
    {
        float valeurInitiale = rectTransform.rect.height;
        float nouvelleValeur = x / 2160f * valeurInitiale;
        return nouvelleValeur;
    }


    public float GetScreenSizeInPixels()
    {
        return GetTheCurrentHeightWindows(Screen.height);
    }

    void OnMovementComplete()
    {

    }
}


