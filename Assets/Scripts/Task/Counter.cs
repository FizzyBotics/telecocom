using UnityEngine;
using TMPro;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField] private Queue queue;
    public TextMeshProUGUI textMesh;
    public float duration = 1f;
    private Coroutine currentCoroutine;

    public void Decrement(int val, int min)
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(DecrementValue(val, min, 1));
    }

    public void Increment(int val, int max)
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(IncrementValue(val, max, 1));
    }

    private IEnumerator DecrementValue(int displayValue, int min, float duration)
    {
        float d = duration / displayValue;
        if (d > 0.3f) d = 0.3f;

        while (displayValue > min)
        {
            displayValue--;
            SetValue(displayValue);
            yield return new WaitForSeconds(d);
        }
    }

    private IEnumerator IncrementValue(int displayValue, int max, float duration)
    {
        float d = duration / displayValue;
        if (d > 0.3f) d = 0.3f;

        while (displayValue < max)
        {
            displayValue++;
            SetValue(displayValue);
            yield return new WaitForSeconds(d);
        }
    }

    public void SetValue(int val) => textMesh.SetText(FormatIntWithSpaces(val));

    private string FormatIntWithSpaces(int number)
    {
        string numberString = number.ToString();

        if (numberString.Length == 1)
        {
            return $"  {numberString}";
        }
        else if (numberString.Length == 2)
        {
            return $" {numberString}";
        }
        else
        {
            return numberString;
        }
    }
}
