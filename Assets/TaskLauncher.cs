using UnityEngine;

public class TaskLauncher : MonoBehaviour
{
    [SerializeField] GameObject taskToLaunch;
    [SerializeField] private TargetToFollow playerMovement;
    private bool started, finish;

    // Update is called once per frame
    private string namee;

    public void Start()
    {

    }


    void OnMouseDown()
    {
        if (!started)
        {
            namee = taskToLaunch.name;
            Debug.Log("le prefab" + taskToLaunch.name + " a été chargé");
            taskToLaunch = Instantiate(taskToLaunch);
            started = true;
        }
    }

    void Update()
    {
        if (started && !finish)
        {
            playerMovement.paused = true;
        }


        if (started && taskToLaunch == null && !finish)
        {
            Debug.Log(">> " + namee + " plus de pause pause !!");
            playerMovement.paused = false;
            finish = true;
        }
    }
}
