using UnityEngine;

public class Objective3 : MonoBehaviour
{
    [SerializeField] Queue queue;
    [SerializeField] Objective objective;
    void Update()
    {
        if (queue.tv.value == 0 && queue.pc.value == 0 && queue.web.value == 0 && queue.phone.value == 0 && !objective.released)
            objective.released = true;
    }
}
