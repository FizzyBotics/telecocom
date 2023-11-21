using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    [SerializeField] private TaskStarter taskStarter;
    [SerializeField] private TaskStartingArea taskArea;

    [SerializeField] private GameObject prefab;

    [SerializeField] private GameObject playerMovement;

    bool taskStarted = false;
    bool finish = false;

    void Start()
    {

    }

    void Awake()
    {
        taskStarter.OnTaskStarted += OnEnterTechnicianTask1;
        taskArea.OnPlayerEnteredArea += OnEnterTechnicianTask1;
    }


    void OnEnterTechnicianTask1()
    {
        if (!taskStarted)
        {
            prefab = Instantiate(prefab);
            taskStarted = true;
            playerMovement.SetActive(false);
        }
    }

    void Update()
    {
        if (taskStarted && prefab == null && !finish)
        {
            playerMovement.SetActive(true);
            finish = true;
        }
    }
}
