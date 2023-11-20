using UnityEngine;

public class WinPopup : MonoBehaviour
{
    [Range(0, 3)] public int stars = 1;
    [SerializeField] private Star star1;
    [SerializeField] private Star star2;
    [SerializeField] private Star star3;


    // Update is called once per frame
    void Update()
    {
        if (stars == 0)
        {
            star1.SetOpacity(0.2f);
            star2.SetOpacity(0.2f);
            star3.SetOpacity(0.2f);
        }
        else if (stars == 1)
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
