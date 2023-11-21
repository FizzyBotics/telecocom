using UnityEngine;

public class TargetToFollow : MonoBehaviour
{
    public bool paused = false;
    void Update()
    {
        if (!paused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                Vector3 newTargetPos = Camera.main.ScreenToWorldPoint(mousePos);
                transform.position = new Vector3(newTargetPos.x, newTargetPos.y, 0);
            }
        }
    }
}
