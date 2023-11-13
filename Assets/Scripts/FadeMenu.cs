using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeMenu;
    public static bool fadeOut = false;
    void Update()
    {
        if (fadeOut && fadeMenu.alpha > 0) fadeMenu.alpha -= Time.deltaTime;
    }
}
