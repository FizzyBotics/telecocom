using UnityEngine;

public class WinPopup : MonoBehaviour
{
    [Range(1, 3)] public int stars;
    [SerializeField] private Star star1, star2, star3;


    void Update()
    {
        if (stars == 1)
        {
            star1.SetOpacity(1);
            star2.SetOpacity(0.2f);
            star3.SetOpacity(0.2f);
        }
        else if (stars == 2)
        {
            star1.SetOpacity(1);
            star2.SetOpacity(1);
            star3.SetOpacity(0.2f);
        }
        else if (stars == 3)
        {
            star1.SetOpacity(1);
            star2.SetOpacity(1);
            star3.SetOpacity(1);
        }
    }
}
