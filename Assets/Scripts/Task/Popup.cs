using TMPro;
using UnityEngine;
public enum Direction { LEFT, RIGHT }

public class Popup : MonoBehaviour
{
    [SerializeField] private GameObject windows;
    [SerializeField] private float duration;

    [SerializeField] private Direction moveSpawndirection;

    private RectTransform rectTransform;

    public TextMeshProUGUI textContent;

    void Start()
    {
        rectTransform = windows.GetComponent<RectTransform>();
        if (moveSpawndirection == Direction.RIGHT)
            MoveRight();
        else
            MoveLeft();
    }

    public float GetTheCurrentWidthWindows(float x)
    {
        float valeurInitiale = rectTransform.rect.width;
        float nouvelleValeur = x / 1920f * valeurInitiale;
        return nouvelleValeur;
    }


    public float GetScreenSizeInPixels()
    {
        return GetTheCurrentWidthWindows(Screen.width);
    }


    public void Disappear()
    {
        if (moveSpawndirection == Direction.RIGHT)
            MoveLeft();
        else
            MoveRight();
    }

    public void MoveRight()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(GetScreenSizeInPixels() / 2.1f, 0f, 0f);
        LeanTween.move(gameObject, endPos, duration)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(OnMovementComplete);
    }

    public void MoveLeft()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(-GetScreenSizeInPixels() / 2.1f, 0f, 0f);
        LeanTween.move(gameObject, endPos, duration)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(OnMovementComplete);
    }


    void OnMovementComplete()
    {
        Debug.Log("Movement Complete");
    }
}
