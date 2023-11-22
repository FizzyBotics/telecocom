using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Objective : MonoBehaviour
{

    private static int width = 40;

    [SerializeField] private TextMeshProUGUI title;

    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private string objectiveDescription;

    [SerializeField] private Image windows;

    public bool released = false;
    private bool animationDone = false;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = windows.GetComponent<RectTransform>();
        title.text = objectiveDescription;
        title.SetText(CenterText(title.text.TrimEnd()));
    }

    void Update()
    {
        if (released && !animationDone) StartCoroutine(LaunchProgressBar());
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
        if (released) gameObject.SetActive(false);
    }

    private IEnumerator LaunchProgressBar()
    {
        float duration = 10;
        while (duration > 0)
        {
            duration--;
            progressBar.value += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        animationDone = true;
    }


    public void MoveToUp()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0f, GetScreenSizeInPixels() / 1.55f, 0f);
        LeanTween.move(gameObject, endPos, 4f)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(OnMovementComplete);
    }

    public void SetReleased(bool b)
    {
        released = b;
    }



    static string CenterText(string text)
    {
        if (text.Length >= width)
        {
            return text;
        }

        int spaces = width - text.Length;
        int leftPadding = spaces / 2;
        int rightPadding = spaces - leftPadding;

        return new string(' ', leftPadding) + text + new string(' ', rightPadding);
    }
}
