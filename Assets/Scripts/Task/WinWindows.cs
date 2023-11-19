using UnityEngine;
public class WinWindows : MonoBehaviour
{
    [SerializeField] private GameObject windows;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = windows.GetComponent<RectTransform>();
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0f, -1.5f * GetScreenSizeInPixels(), 0f);
        LeanTween.move(gameObject, endPos, 1.3f)
            .setEase(LeanTweenType.easeOutQuad)
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
