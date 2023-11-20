using UnityEngine;

public class Objective3 : MonoBehaviour
{
    [SerializeField] Queue queue;
    [SerializeField] Objective objective;
    void Update()
    {
        if (queue.AllElementsZero() && !objective.released)
            objective.released = true;
    }
}
