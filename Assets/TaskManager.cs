using UnityEngine;

public class TaskManager : MonoBehaviour
{

    [SerializeField] private TaskStarter taskStarter;

    [SerializeField] private GameObject prefab;

    [SerializeField] private TargetToFollow playerMovement;

    bool taskStarted = false;
    bool finish = false;

    void Start()
    {

    }

    void Awake()
    {
        taskStarter.OnTaskStarted += OnEnterTechnicianTask1;
    }


    void OnEnterTechnicianTask1()
    {
        if (!taskStarted)
        {
            prefab = Instantiate(prefab);
            taskStarted = true;
            playerMovement.paused = true;
        }
    }

    void Update()
    {
        if (taskStarted && prefab == null && !finish)
        {
            playerMovement.paused = false;
            finish = true;
        }
    }
}
