using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class TaskStartingArea : MonoBehaviour
{
    public CircleCollider2D taskStartingArea;
    public delegate void TaskStartingAreaDelegate();
    public event TaskStartingAreaDelegate OnPlayerEnteredArea;

    private void Awake()
    {
        taskStartingArea = GetComponent<CircleCollider2D>();
        taskStartingArea.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) OnPlayerEnteredArea?.Invoke();
    }

    private Collider2D[] GetCollisionList()
    {
        return Physics2D.OverlapCircleAll(transform.position, taskStartingArea.radius);
    }

    public bool IsPlayerInArea()
    {
        foreach (Collider2D collider in GetCollisionList())
        {
            if (collider.gameObject.CompareTag("Player")) return true;
        }
        return false;
    }
}
