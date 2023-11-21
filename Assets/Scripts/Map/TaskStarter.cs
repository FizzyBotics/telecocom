using UnityEngine;

public class TaskStarter : MonoBehaviour
{
	[SerializeField] private TaskStartingArea taskStartingArea;
	public bool currentlySelected = false;
	public delegate void TaskStarterDelegate();
	public event TaskStarterDelegate OnTaskStarted;

	private void Awake()
	{
		taskStartingArea.OnPlayerEnteredArea += OnPlayerEnteredArea;
	}

	public void OnMouseDown()
	{
		if (taskStartingArea.IsPlayerInArea())
		{
			Debug.Log("Player found in area, starting task");
			StartTask();
		}
		else
		{
			Debug.Log("No player found in area, selecting task starter for later");
			currentlySelected = true;
		}
	}

	private void StartTask()
	{
		OnTaskStarted?.Invoke();
		Debug.Log("Task started");
	}

	private void OnPlayerEnteredArea()
	{
		if (currentlySelected)
		{
			StartTask();
			currentlySelected = false;
		}
	}
}