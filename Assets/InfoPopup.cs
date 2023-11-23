using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPopup : MonoBehaviour
{
    public static InfoPopup Instance;
    void Start()
    {
        Instance = this;
    }
}
