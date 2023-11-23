using UnityEngine;

public class TechnicianTask1 : MonoBehaviour
{
    [SerializeField] Objective2Popup objective2;
    [SerializeField] Queue queue;
    void Start()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        queue.canva = parent;
        objective2.canva = parent;
    }
    void Delete()
    {
        Destroy(gameObject);
    }
}
