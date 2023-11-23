using UnityEngine;

public class Objective3 : MonoBehaviour
{
    [SerializeField] Queue queue;
    [SerializeField] Objective objective;
    void Update()
    {
        if (queue.AllElementsZero() && !objective.released && queue.values.Count > 0)
        {
            objective.released = true;
        }
    }
}
