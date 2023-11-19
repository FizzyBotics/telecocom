using UnityEngine;
using TMPro;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField] private Queue queue;
    public TextMeshProUGUI textMesh;
    public float duration = 1f;
    [Range(0, 90)] public int value;

    public void Start() => SetValue(value);

    public void Decrement(int min) => StartCoroutine(DecrementValue(min, 1));
    public void Increment(int max) => StartCoroutine(IncrementValue(max, 1));


    private IEnumerator DecrementValue(int min, float duration)
    {
        Debug.Log($"Décrémentation en cours: {value} -> {min}");
        int currentValue = value;
        float d = duration / currentValue;
        if (d > 0.3f)
        {
            d = 0.3f;
        }

        while (value > min)
        {
            value--;
            SetValue(value);
            yield return new WaitForSeconds(d);
        }
        Debug.Log($"Décrémentation finie: {currentValue} -> {value}");
    }

    private IEnumerator IncrementValue(int max, float duration)
    {

        Debug.Log($"Incrémentation en cours: {value} -> {max}");
        int currentValue = value;
        float d = duration / currentValue;
        if (d > 0.3f)
        {
            d = 0.3f;
        }
        while (value < max)
        {
            value++;
            SetValue(value);
            yield return new WaitForSeconds(d);
        }
        Debug.Log($"Incrémentation finie: {currentValue} -> {value}");
    }

    public void SetValue(int value) => textMesh.SetText(FormatIntWithSpaces(value));

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
